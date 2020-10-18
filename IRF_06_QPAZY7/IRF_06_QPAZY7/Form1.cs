using IRF_06_QPAZY7.Entities;
using IRF_06_QPAZY7.MnbServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace IRF_06_QPAZY7
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();
        BindingList<string> Currencies = new BindingList<string>();

        public Form1()
        {
            InitializeComponent();            
            RefreshData();            
        }

        private void RefreshData()
        {
            //utolsó feladat
            dateTimePicker1.Value = DateTime.Today.Subtract(TimeSpan.FromDays(100));
            comboBox1.Text = "EUR";
            Rates.Clear();            
            webservicecall();
            dataGridView1.DataSource = Rates;
            //feladat();
            hatos();
            comboBox1.DataSource = Currencies.ToList();
           
        }

        private void hatos()
        {
            chartRateData.DataSource = Rates;

            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var legend = chartRateData.Legends[0];
            legend.Enabled = false;

            var chartArea = chartRateData.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
        }

        private void webservicecall()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();
            
            var request = new GetExchangeRatesRequestBody()
            {                
                currencyNames = "EUR",
                startDate = dateTimePicker1.Value.ToString(),
                endDate = dateTimePicker2.Value.ToString(),
            };
            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;

            var xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement element in xml.DocumentElement)
            {
                var rate = new RateData();
                Rates.Add(rate);
                // Dátum
                rate.Date = DateTime.Parse(element.GetAttribute("date"));
                // Valuta
                var childElement = (XmlElement)element.ChildNodes[0];
                rate.Currency = childElement.GetAttribute("curr");
                // Érték
                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                    rate.Value = value / unit;
            }            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
    
}

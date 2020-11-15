namespace IRF_08_QPAZY7
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.createTimer = new System.Windows.Forms.Timer(this.components);
            this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
            this.btn_SelectCar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SelectBall = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.btn_SelectBall);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.btn_SelectCar);
            this.mainPanel.Location = new System.Drawing.Point(12, 27);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(776, 411);
            this.mainPanel.TabIndex = 0;
            // 
            // createTimer
            // 
            this.createTimer.Enabled = true;
            this.createTimer.Interval = 3000;
            this.createTimer.Tick += new System.EventHandler(this.createTimer_Tick);
            // 
            // conveyorTimer
            // 
            this.conveyorTimer.Enabled = true;
            this.conveyorTimer.Interval = 10;
            this.conveyorTimer.Tick += new System.EventHandler(this.conveyorTimer_Tick);
            // 
            // btn_SelectCar
            // 
            this.btn_SelectCar.Location = new System.Drawing.Point(379, 143);
            this.btn_SelectCar.Name = "btn_SelectCar";
            this.btn_SelectCar.Size = new System.Drawing.Size(98, 67);
            this.btn_SelectCar.TabIndex = 0;
            this.btn_SelectCar.Text = "CAR";
            this.btn_SelectCar.UseVisualStyleBackColor = true;
            this.btn_SelectCar.Click += new System.EventHandler(this.btn_SelectCar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(507, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Coming Next :";
            // 
            // btn_SelectBall
            // 
            this.btn_SelectBall.Location = new System.Drawing.Point(549, 143);
            this.btn_SelectBall.Name = "btn_SelectBall";
            this.btn_SelectBall.Size = new System.Drawing.Size(98, 67);
            this.btn_SelectBall.TabIndex = 2;
            this.btn_SelectBall.Text = "BALL";
            this.btn_SelectBall.UseVisualStyleBackColor = true;
            this.btn_SelectBall.Click += new System.EventHandler(this.btn_SelectBall_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        public System.Windows.Forms.Timer createTimer;
        public System.Windows.Forms.Timer conveyorTimer;
        private System.Windows.Forms.Button btn_SelectBall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SelectCar;
    }
}


using IRF_08_QPAZY7.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRF_08_QPAZY7.Entities
{
    class Carfactory : IToyFactory
    {        
        public Toy CreateNew()
        {
            return new Ball();
        }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSensorDemo.Models
{
    class Measure
    {
        public double Value { get; set; }

        public Measure(double value)
        {
            this.Value = value;
        }
    }
}

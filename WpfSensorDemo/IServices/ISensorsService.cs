using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSensorDemo.Models;

namespace WpfSensorDemo.IServices
{
    interface ISensorsService
    {
        event EventHandler<Measure> SensorChanged;
    }
}

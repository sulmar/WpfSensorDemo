using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSensorDemo.IServices;
using WpfSensorDemo.Models;

namespace WpfSensorDemo.Services
{
    class MockSensorsService : ISensorsService
    {
        public event EventHandler<Measure> SensorChanged;

        private System.Threading.Timer timer;
        private readonly Random random = new Random();

        protected void OnSensorChanged(Measure measure)
        {
            SensorChanged?.Invoke(this, measure);
        }


        public MockSensorsService()
        {
            timer = new System.Threading.Timer(new System.Threading.TimerCallback(CallbackMethod), null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1));
        }

        private void CallbackMethod(object oStateObject)
        {
            var measure = new Measure(random.NextDouble());

            OnSensorChanged(measure);

        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var measure = new Measure(random.NextDouble());

            OnSensorChanged(measure);
        }
    }
}

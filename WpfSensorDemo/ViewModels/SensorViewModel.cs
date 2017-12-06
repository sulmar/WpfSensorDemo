using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSensorDemo.IServices;
using WpfSensorDemo.Models;
using WpfSensorDemo.Services;

namespace WpfSensorDemo.ViewModels
{
    class SensorViewModel : BaseViewModel
    {
        private readonly ISensorsService sensorsService;

        private Measure _CurrentMeasure;
        public Measure CurrentMeasure
        {
            get
            {
                return _CurrentMeasure;
            }
            set
            {
                _CurrentMeasure = value;
                OnPropertyChanged();
            }
        }

        public SensorViewModel()
            : this(new MockSensorsService())
        {

        }

        public SensorViewModel(ISensorsService sensorsService)
        {
            this.sensorsService = sensorsService;

            this.sensorsService.SensorChanged += SensorsService_SensorChanged;

        }

        private void SensorsService_SensorChanged(object sender, Models.Measure e)
        {
            Console.WriteLine(e.Value);

            CurrentMeasure = e;
        }
    }
}

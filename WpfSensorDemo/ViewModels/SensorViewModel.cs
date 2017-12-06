using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSensorDemo.Common;
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

        public ObservableCollection<Measure> Measures { get; set; }

        public SensorViewModel()
            : this(new MockSensorsService())
        {

        }

        public SensorViewModel(ISensorsService sensorsService)
        {
            this.sensorsService = sensorsService;

            this.Measures = new ObservableCollection<Measure>();

            this.sensorsService.SensorChanged += SensorsService_SensorChanged;

        }

        private void SensorsService_SensorChanged(object sender, Models.Measure e)
        {
            Trace.WriteLine(e.Value);

            // error
            // Measures.Add(e);

            // thread-safe
            DispatchService.Invoke(() =>
            {
                this.Measures.Add(e);
            });

            CurrentMeasure = e;

            
        }
    }
}

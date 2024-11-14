using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoWeatherApp.Models
{
    public class TelemetryModel
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public DateTime LocalTime { get; set; }
    }
}

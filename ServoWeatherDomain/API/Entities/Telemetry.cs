using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoWeatherDomain.API.Entities
{
    public class Telemetry
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public DateTime Time { get; set; }
    }
}

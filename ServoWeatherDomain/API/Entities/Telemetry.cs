

namespace ServoWeatherDomain.API.Entities
{
    public class Telemetry
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public DateTime LocalTime { get; set; }
    }
}

using ServoWeatherDomain.API.Entities;
using ServoWeatherWeb.Models;

namespace ServoWeatherWeb.Mapping
{
    public static class MapFromEntityToModel
    {
        public static TelemetryModel ConvertFromEntityToModel(this Telemetry obj)
        {
            TelemetryModel model = new()
            {
                Humidity = obj.Humidity,
                Temperature = obj.Temperature,
                LocalTime = obj.LocalTime
            };
            return model;
        }


        public static Telemetry ConvertFromModelToEntity(this TelemetryModel obj)
        {
            Telemetry model = new Telemetry
            {
                Humidity = obj.Humidity,
                Temperature = obj.Temperature,
                LocalTime = obj.LocalTime
            };
            return model;
        }
    }
}

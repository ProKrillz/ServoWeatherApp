using ServoWeatherApp.Models;
using ServoWeatherDomain.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoWeatherApp.Mapping
{
    public static class MapFromEntityToModel
    {
        public static TelemetryModel ConvertFromEntityToModel(this Telemetry obj)
        {
            TelemetryModel model = new ()
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

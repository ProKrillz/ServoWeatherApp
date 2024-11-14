using InfluxDB3.Client;
using InfluxDB3.Client.Write;
using ServoWeatherDomain.API.Entities;
using ServoWeatherDomain.API.InfluxDBRepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoWeatherDomain.API.InfluxDBRepositories
{
    public class InfluxRepository : IInfluxRepository
    {
        const string _hostUrl = "https://us-east-1-1.aws.cloud2.influxdata.com";
        const string? _database = "Telemetry";
        const string? _authToken = "HjLJOoBv8IWFQ-eRVUpPspWLNWb_BQvhlDMqdYnWTfa33V2sViEanGGiwWa1UhQqkf3gDAzgAcNNDVKoJs0iBw==";

        public async Task WriteTelemetry(Telemetry telemetry)
        {

            using var client = new InfluxDBClient(_hostUrl, token: _authToken, database: _database);

            var point = PointData.Measurement("TemperatureData")
                .SetField("Temperature", telemetry.Temperature)
                .SetField("Humidity", telemetry.Humidity)
                .SetTimestamp(DateTime.UtcNow.AddSeconds(-10));
            await client.WritePointAsync(point: point);
        }
        public async Task<List<Telemetry>> QuereDB()
        {
            const string quereAll = "SELECT * FROM 'TemperatureData'";

            List<Telemetry> list = new List<Telemetry>();

            using var client = new InfluxDBClient(_hostUrl, token: _authToken, database: _database);

            await foreach (var row in client.Query(quereAll))
            {
                list.Add(new Telemetry()
                {
                    Humidity = Convert.ToDouble(row[0]),
                    Temperature = Convert.ToDouble(row[1]),
                    LocalTime = DateTime.Parse(row[2].ToString()).ToLocalTime(), // show in local time
                });
            }
            return list;


        }
    }
}

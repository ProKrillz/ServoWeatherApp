using Google.Protobuf.WellKnownTypes;
using InfluxDB3.Client;
using InfluxDB3.Client.Write;
using ServoWeatherDomain.API.Entities;
using ServoWeatherDomain.API.InfluxDBRepositories.Interfaces;

namespace ServoWeatherDomain.API.InfluxDBRepositories;

public class InfluxRepository(InfluxDBClient _influxDBClient) : IInfluxRepository
{
    private readonly InfluxDBClient _influxDBClient = _influxDBClient;

    const string hostUrl = "https://us-east-1-1.aws.cloud2.influxdata.com";
    const string? database = "Telemetry";
    const string? authToken = "HjLJOoBv8IWFQ-eRVUpPspWLNWb_BQvhlDMqdYnWTfa33V2sViEanGGiwWa1UhQqkf3gDAzgAcNNDVKoJs0iBw==";
    public async Task WriteTelemetry(Telemetry telemetry)
    {
        using var client = _influxDBClient;

        PointData point = PointData.Measurement("TemperatureData")
            .SetField("Temperature", telemetry.Temperature)
            .SetField("Humidity", telemetry.Humidity)
            .SetTimestamp(DateTime.UtcNow.AddSeconds(-10));
        await client.WritePointAsync(point: point);
    }
    public async Task<List<Telemetry>> QuereDbAsync(string option)
    {
        string quere = option switch
        {
            "All" => "SELECT * FROM 'TemperatureData' WHERE 'Humidity' IS NOT NULL OR 'Temperature' IS NOT NULL",
            "LastHour" => "SELECT * FROM 'TemperatureData' WHERE time >= now() - interval '1 hour' AND 'Humidity' IS NOT NULL OR 'Temperature' IS NOT NULL",
            "Today" => "SELECT * FROM 'TemperatureData' WHERE time >= today() AND 'Humidity' IS NOT NULL OR 'Temperature' IS NOT NULL"
        };
     
        List<Telemetry> list = new List<Telemetry>();

        using var client = new InfluxDBClient(hostUrl, token: authToken, database: database);

        await foreach (var row in client.Query(quere))
        {
            list.Add(new Telemetry()
            {
                Humidity = Convert.ToDouble(row[0]),
                Temperature = Convert.ToDouble(row[1]),
                LocalTime = DateTime.Parse(row[2].ToString()).ToLocalTime(), // show in local time
            });
        }

        list = list.GroupBy(x => x.LocalTime.ToString("yy/MM/dd HH/mm"))
            .Select(x =>
            {
                var average = x.First();
                average.Humidity = x.Average(y => y.Humidity);
                average.Temperature = x.Average(y => y.Temperature);
                average.LocalTime = new DateTime((long)x.Average(item => item.LocalTime.Ticks));
                return average;
            }).Take(15).ToList();
        return list;
    }
}

using ServoWeatherDomain.API.Entities;

namespace ServoWeatherDomain.API.InfluxDBRepositories.Interfaces;

public interface IInfluxRepository
{
    Task WriteTelemetry(Telemetry telemetry);
    /// <summary>
    /// option is for witch quere to use read readme
    /// </summary>
    /// <param name="option"></param>
    /// <returns></returns>
    Task<List<Telemetry>> QuereDbAsync(string option);

}

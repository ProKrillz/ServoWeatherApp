using ServoWeatherDomain.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoWeatherDomain.API.InfluxDBRepositories.Interfaces
{
    public interface IInfluxRepository
    {
        Task WriteTelemetry(Telemetry telemetry);

        Task<List<Telemetry>> QuereDB();
    }
}

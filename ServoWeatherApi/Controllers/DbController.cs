using Microsoft.AspNetCore.Mvc;
using ServoWeatherDomain.API.Entities;
using ServoWeatherDomain.API.InfluxDBRepositories.Interfaces;

namespace ServoWeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbController(IInfluxRepository _repository) : Controller
    {
        private readonly IInfluxRepository _repository = _repository;

        public async Task<List<Telemetry>>GetTelemetryAsync()
        {
            return await _repository.QuereDB();
        }
    }
}

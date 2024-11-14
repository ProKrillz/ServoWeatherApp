using Microsoft.AspNetCore.Mvc;
using ServoWeatherDomain.API.MqttRepositories.Interfaces;

namespace ServoWeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MqttController(ILogger<MqttController> _logger, IPublishRepository _repository) : Controller
    {
        private readonly ILogger<MqttController> _logger = _logger;

        private readonly IPublishRepository _repository = _repository;
        
        public async Task ActivateServoAsync(string status)
        {
            await _repository.PublishApplicationMessageAsync(status);
        }
    }
}

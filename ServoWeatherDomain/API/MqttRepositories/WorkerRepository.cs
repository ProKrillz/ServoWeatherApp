using Microsoft.Extensions.Logging;
using MQTTnet.Client;
using MQTTnet.Extensions.TopicTemplate;
using MQTTnet;
using System.Text;
using ServoWeatherDomain.API.InfluxDBRepositories.Interfaces;
using System.Text.Json;
using ServoWeatherDomain.API.Entities;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace ServoWeatherDomain.API.MqttRepositories
{
    public class WorkerRepository : BackgroundService
    {
        static readonly MqttTopicTemplate sampleTemplate = new("home/temp");

        private readonly ILogger<WorkerRepository> _logger;
        
        private readonly  IInfluxRepository _influxDBService;

        private readonly IConfiguration _config;

        private readonly IMqttClient _mqttClient;
        
        private readonly MqttClientOptionsBuilder _mqttClientOptionsBuilder;


        public WorkerRepository(IInfluxRepository iInfluxDBService, IMqttClient mqttClient, MqttClientOptionsBuilder mqttClientOptions, ILogger<WorkerRepository> logger)
        {
            _influxDBService = iInfluxDBService;
            _logger = logger;
            _mqttClient = mqttClient;
            _mqttClientOptionsBuilder = mqttClientOptions;
            
            _config = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly())
                .Build();
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken) { } //create more instance

        public async override Task StartAsync(CancellationToken stoppingToken) //creates one instance
        {
            _mqttClient.ApplicationMessageReceivedAsync += e =>
            {
                Telemetry? found = JsonSerializer.Deserialize<Telemetry>(Encoding.Default.GetString(e.ApplicationMessage.PayloadSegment));
                _logger.LogInformation("random");
                _influxDBService.WriteTelemetry(found);
                return Task.CompletedTask;
            };
            await _mqttClient.ConnectAsync(_mqttClientOptionsBuilder.WithCredentials(_config["DeivceOneUsername"], _config["DeivceOnePassword"]).Build(), CancellationToken.None);

            var mqttSubscribeOptions = new MqttClientSubscribeOptionsBuilder().WithTopicTemplate(sampleTemplate).Build();

            await _mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
        }
    }
}

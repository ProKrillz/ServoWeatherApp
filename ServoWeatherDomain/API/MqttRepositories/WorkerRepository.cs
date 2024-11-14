using Microsoft.Extensions.Logging;
using MQTTnet.Client;
using MQTTnet.Extensions.TopicTemplate;
using MQTTnet.Formatter;
using MQTTnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServoWeatherDomain.API.InfluxDBRepositories.Interfaces;
using System.ComponentModel;
using System.Text.Json;
using ServoWeatherDomain.API.Entities;
using Microsoft.Extensions.Hosting;

namespace ServoWeatherDomain.API.MqttRepositories
{
    public class WorkerRepository : BackgroundService
    {
        static readonly MqttTopicTemplate sampleTemplate = new("home/temp");

        private readonly  IInfluxRepository _influxDBService;

        private readonly ILogger<WorkerRepository> _logger;

        public WorkerRepository(IInfluxRepository iInfluxDBService, ILogger<WorkerRepository> logger)
        {
            _influxDBService = iInfluxDBService;
            _logger = logger;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken) { } //create more instance

        public async override Task StartAsync(CancellationToken stoppingToken) //creates one instance
        {
            var mqttFactory = new MqttFactory();

            IMqttClient mqttClient = mqttFactory.CreateMqttClient();

            var mqttClientOptions = new MqttClientOptionsBuilder()
                 .WithTcpServer("49987f455bc94d2183a5075a9fa78344.s1.eu.hivemq.cloud", 8883)
                 .WithCredentials("MQTT.fx", "linkin")
                 .WithProtocolVersion(MqttProtocolVersion.V311)
                 .WithTlsOptions(x => x.UseTls())
                 .Build();

            mqttClient.ApplicationMessageReceivedAsync += e =>
            {
                Telemetry? found = JsonSerializer.Deserialize<Telemetry>(Encoding.Default.GetString(e.ApplicationMessage.PayloadSegment));
                _logger.LogInformation("random");
                _influxDBService.WriteTelemetry(found);
                return Task.CompletedTask;
            };
            await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

            var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder().WithTopicTemplate(sampleTemplate).Build();

            await mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
        }
    }
}

using MQTTnet.Client;
using MQTTnet;
using ServoWeatherDomain.API.MqttRepositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using MQTTnet.Server;

namespace ServoWeatherDomain.API.MqttRepositories
{
    public class PublishRepository : IPublishRepository
    {
        private readonly IConfiguration _config;

        private IMqttClient _mqttClient;

        private readonly MqttClientOptionsBuilder _mqttClientOptionsBuilder;

        public PublishRepository(IMqttClient mqttClient, MqttClientOptionsBuilder mqttClientOptions)
        {
            _mqttClient = mqttClient;
            _mqttClientOptionsBuilder = mqttClientOptions;
            
            _config = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly())
                .Build();
        }
        public async Task PublishApplicationMessageAsync(string input)
        {
            MqttFactory mqttFactory = new MqttFactory();
            using (_mqttClient = mqttFactory.CreateMqttClient())
            {
                await _mqttClient.ConnectAsync(_mqttClientOptionsBuilder.WithCredentials(_config["DeivceTwoUsername"], _config["DeivceTwoPassword"]).Build(), CancellationToken.None);

                var applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic("servo/rotate")
                    .WithPayload(input)
                    .Build();

                await _mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

                await _mqttClient.DisconnectAsync();
            }
        }
    }
}

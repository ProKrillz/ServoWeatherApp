﻿using MQTTnet.Client;
using MQTTnet.Formatter;
using MQTTnet;
using System;
using System.Collections.Generic;
using System.Linq;
using ServoWeatherDomain.API.MqttRepositories.Interfaces;

namespace ServoWeatherDomain.API.MqttRepositories
{
    public class PublishRepository : IPublishRepository
    {
        public async Task PublishApplicationMessageAsync(string input)
        {
            /*number
             * This sample pushes a simple application message including a topic and a payload.
             *
             * Always use builders where they exist. Builders (in this project) are designed to be
             * backward compatible. Creating an _MqttApplicationMessage_ via its constructor is also
             * supported but the class might change often in future releases where the builder does not
             * or at least provides backward compatibility where possible.
             */

            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder()
                   .WithTcpServer("49987f455bc94d2183a5075a9fa78344.s1.eu.hivemq.cloud", 8883)
                   .WithCredentials("MQTTTX", "linkin")
                   .WithProtocolVersion(MqttProtocolVersion.V310)
                   .WithTlsOptions(x => x.UseTls())
                   .Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                var applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic("servo/rotate")
                    .WithPayload(input)
                    .Build();

                await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

                await mqttClient.DisconnectAsync();

                Console.WriteLine("MQTT application message is published.");
            }
        }
    }
}

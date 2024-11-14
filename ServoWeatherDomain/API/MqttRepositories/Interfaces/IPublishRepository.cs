using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoWeatherDomain.API.MqttRepositories.Interfaces
{
    public interface IPublishRepository
    {
        Task Publish_Application_Message(string number);
    }
}

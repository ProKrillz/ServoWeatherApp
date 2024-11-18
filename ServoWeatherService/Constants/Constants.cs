using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoWeatherService.Constants
{
    public class Constants
    {
        #region Brian Tunnel

        public static string BaseUrl = "https://cb0q7p4s-7260.euw.devtunnels.ms"; // Brian

        #endregion

        #region Thomas Tunnel

        //public static string BaseUrl = "https://4mcjs4n2-7260.euw.devtunnels.ms"; // Thomas

        #endregion
        public static string Endpoint = "GetTelemtry";
        public static string EndpointServo = "api/Mqtt/activate";
    }
}

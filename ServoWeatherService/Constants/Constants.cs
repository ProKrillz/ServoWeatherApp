

namespace ServoWeatherService.Constants
{
    public class Constants
    {
        #region Brian Tunnel

        public static string BaseUrl = "https://localhost:7260"; // Brian

        #endregion

        #region Thomas Tunnel
        
        //public static string BaseUrl = "https://4mcjs4n2-7260.euw.devtunnels.ms"; // Thomas
        //public static string BaseUrl = "https://localhost:7260/";

        #endregion
        public static string Endpoint = "GetTelemtry";
        public static string EndpointServo = "api/Mqtt/activate";
    }
}

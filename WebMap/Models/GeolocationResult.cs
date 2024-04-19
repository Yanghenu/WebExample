using static WebMap.Controllers.MainPageController;

namespace WebMap.Models
{
    public class GeolocationResult
    {
        public Position position { get; set; }
        public string location_type { get; set; }
        public string message { get; set; }
        public int accuracy { get; set; }
        public bool isConverted { get; set; }
        public int status { get; set; }
        public string info { get; set; }
    }

    public class Position
    {
        public double Q { get; set; }
        public double R { get; set; }
        public double lng { get; set; }
        public double lat { get; set; }
    }

    public class UserInfo
    {
        public GeolocationResult Geolocation { get; set; }
        public string UserName { get; set; }
    }
}

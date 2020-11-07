using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherMap.Models
{
    public class PollutionViewModel
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string DateTime { get; set; }
        public string apikey { get; set; }
        public string response { get; set; }
    }
}
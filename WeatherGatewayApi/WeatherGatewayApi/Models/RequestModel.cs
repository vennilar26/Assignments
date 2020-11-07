using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherGatewayApi.Models
{
    public class RequestModel
    {
        public string APIURI { get; set; }
        public string APIKEY { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string DateTime { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherGatewayApi.Models
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public string Data { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
   public  class PollutionRequest
    {
        public string APIURI { get; set; }
        public string APIKEY { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string DateTime { get; set; }
    }
}

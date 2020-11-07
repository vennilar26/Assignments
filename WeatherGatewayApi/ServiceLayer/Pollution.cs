using Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    /// <summary>
    /// Pollution class to implement IPollution service    
    /// </summary>
    public class Pollution : IPollution
    {
        private Logger1 log;

        /// <summary>
        /// Pollution constructor to inject class name for Logger     
        /// </summary>
        public Pollution()
        {
            this.log = new Logger1("Pollution");
        }

        /// <summary>
        /// GetPollutionByGeographic method to call weather map api     
        /// </summary>
        public PollutionResponse GetPollutionByGeographic(PollutionRequest pollutionRequest)
        {
            log.Log("Begin");
            PollutionResponse result = new PollutionResponse();
            string uri = pollutionRequest.APIURI;
           // pollutionRequest.DateTime = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            uri = pollutionRequest.APIURI+"/"+pollutionRequest.Latitude+","+pollutionRequest.Longitude+"/"+pollutionRequest.DateTime+"Z.json?appid=" + pollutionRequest.APIKEY;
            log.Log("URI :"+uri);
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(uri).Result;
                    log.Log("Response :" + response);
                                          
                        var responseContent = response.Content;

                    result.Data = responseContent.ReadAsStringAsync().Result;
                    result.Status = response.StatusCode.ToString();
                    result.Message = result.Data;


                }
            }
            catch(Exception ex)
            {
                log.ErrorLog(ex,"Error Occured");
                throw;
            }
            log.Log("End");
            return result;
        }
    }
}

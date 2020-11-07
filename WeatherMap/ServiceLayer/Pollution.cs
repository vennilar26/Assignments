using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    /// <summary>
    /// Class to receive the input and process    
    /// </summary>
    public class Pollution
    {
        /// <summary>
        /// To get pollution values by calling  gateway api   
        /// </summary>
        public PollutionEnity GetPollution(PollutionEnity entity)
        {
            string URI= ConfigurationManager.AppSettings["POLLUTIONURI"];           

            using (var httpClient = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    {"Latitude", entity.Latitude},
                    {"Longitude", entity.Longitude},
                    {"APIKEY","ee00fb47757b05782a72d6161eb3c04f" },
                    { "DateTime",DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}
                };
                var content = new FormUrlEncodedContent(values);
                content.Headers.Clear();
                content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                var response = httpClient.PostAsync(URI, content).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contents = response.Content.ReadAsStringAsync().Result;
                    JObject obj = JObject.Parse(contents.ToString());
                    if (obj.ContainsKey("Message"))
                    {
                        entity.response = (string)obj["Message"];
                    }
                }
            }
            
            return entity;
        }
       

    }
}

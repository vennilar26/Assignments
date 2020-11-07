using Logging;
using Newtonsoft.Json.Linq;
using NLog;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WeatherGatewayApi.Models;

namespace WeatherGatewayApi.Controllers
{
    /// <summary>
    /// Weather controller to process request from MVC    
    /// </summary>
    public class WeatherController : ApiController
    {
        private IPollution _pollution ;
        private Logger1 log;

        // <summary>
        /// WeatherController constructor to inject service object for serivce layer        
        /// </summary>
        public WeatherController(IPollution pollution)
        {
            this._pollution = pollution;
            log = new Logger1("WeatherController");
        }

        /// <summary>
        /// Post method to receive the request for the api call      
        /// </summary>
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]RequestModel Request)
        {
           
            log.Log("Weather Controller - Begin");
            log.Log(Request.ToString());
            ResponseModel response = new ResponseModel();
            PollutionRequest pollutionRequest = new PollutionRequest();
            pollutionRequest.APIURI = "http://api.openweathermap.org/pollution/v1/o3";
            pollutionRequest.APIKEY = Request.APIKEY;
            pollutionRequest.Latitude = Request.Latitude;
            pollutionRequest.Longitude = Request.Longitude;
            pollutionRequest.DateTime = Request.DateTime;
            try
            {
                PollutionResponse responseObj = await Task.Run(() => this._pollution.GetPollutionByGeographic(pollutionRequest));
                log.Log("Return message from service layer :"+ responseObj.ToString());
                //if (String.IsNullOrEmpty(responsestring.))
                //{
                //    response.Status = HttpStatusCode.NotFound.ToString();
                //    response.Message = "Not Found";
                //    return NotFound();
                //}
                response.Message = responseObj.Message;
                response.Status = responseObj.Status;
                response.Data = responseObj.Data;

                JObject obj = JObject.Parse(response.Data);                
                if (obj.ContainsKey("message"))
                {
                    response.Message = (string)obj["message"];
                }
                
            }
            catch(Exception ex)
            {
                log.ErrorLog(ex, "Error Occured");
                return InternalServerError();
            }
            log.Log("Weather Controller - End");
            return Ok(response);
        }
    }
}

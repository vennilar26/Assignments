using Newtonsoft.Json;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WeatherMap.Models;

namespace WeatherMap.Controllers
{
    /// <summary>
    /// Home controller to get home page request      
    /// </summary>
    public class HomeController : Controller
    {
        Pollution _pollutionObj = new Pollution();
        PollutionViewModel viewModel;
        /// <summary>
        /// Get method to return home page view    
        /// </summary>
        public ActionResult Index()
        {
                
            return View(viewModel);
        }
        /// <summary>
        /// Post method to receive user input from home page view    
        /// </summary>
        [HttpPost]
        public ActionResult Index(PollutionViewModel pollutionViewModel)
        {

            viewModel = new PollutionViewModel();
            PollutionEnity entity = new PollutionEnity();
            
            entity.Latitude = pollutionViewModel.Latitude;
            entity.Longitude = pollutionViewModel.Longitude;
            entity =  _pollutionObj.GetPollution(entity);
            viewModel.response = entity.response;
            viewModel.Latitude = entity.Latitude;
            viewModel.Longitude = entity.Longitude;
            if (!String.IsNullOrEmpty(entity.response))
            {
                return View(viewModel);
            }
            return View("Error");

           // return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
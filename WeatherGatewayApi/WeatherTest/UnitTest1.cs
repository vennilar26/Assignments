using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer;
using WeatherGatewayApi.Controllers;
using WeatherGatewayApi.Models;

namespace WeatherTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// To test Weather/Post method
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task  TestMethod1()
        {
            // Arrange

            var requestModel = new RequestModel();
            requestModel.APIURI = "http://api.openweathermap.org/pollution/v1/o3";
            requestModel.APIKEY = "ee00fb47757b05782a72d6161eb3c04f";
            requestModel.Latitude = "12.8";
            requestModel.Longitude = "77";
            requestModel.DateTime = "2020-11-07";

            var responsemodel = new ResponseModel();
            var pollution = new Pollution();
            var controller = new WeatherController(pollution);

            // Act
            System.Threading.Tasks.Task<IHttpActionResult> actionResult = controller.Post(requestModel);
            var contentResult =await actionResult as OkNegotiatedContentResult<ResponseModel>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);

            Assert.IsInstanceOfType(contentResult.Content, typeof(ResponseModel));
            Assert.IsInstanceOfType(contentResult.Content.Message, typeof(string));
        }
    }
}

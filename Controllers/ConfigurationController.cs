using IPOApi.Models;
using IPOApi.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace IPOApi.Controllers
{
    //[Route("[controller]")]
    public class ConfigurationController : Controller
    {
        private IConfiguration _configuration;

        public ConfigurationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        string constring = "";

        [HttpPost("fetchconfig")]
        public IActionResult fetchconfig()
        {
            DataTable response = new DataTable();

            try
            {
                constring = _configuration
                    .GetSection("Appsettings")["ConnectionStrings"]
                    .ToString();

                response = ConfigurationService.fetchconfigservice(constring);

                var serializedProduct = JsonConvert.SerializeObject(
                    response,
                    Formatting.None
                );

                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("updateconfig")]
        public IActionResult UpdateConfig([FromBody] ConfigurationModel objConfig)
        {
            try
            {
                constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
                string json = JsonConvert.SerializeObject(objConfig);
                //string userId = Request.Headers["user_id"].FirstOrDefault();
                DataTable response = ConfigurationService.UpdateConfig(json,constring);
                var serializedProduct =JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }
    }
}
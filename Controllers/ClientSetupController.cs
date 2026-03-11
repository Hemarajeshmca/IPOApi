using IPOApi.Models;
using IPOApi.STADataAccess;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace IPOApi.Controllers
{
    public class ClientSetupController : Controller
    {
        private IConfiguration _configuration;
        public ClientSetupData objData = new ClientSetupData();
        public ClientSetupController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        string constring = "";

        [HttpPost("ClientType")]
        public IActionResult ClientType([FromBody] ClientSetupModel inscObj)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            DataSet response = new DataSet();
            try
            {
                response = objData.getclientType(inscObj, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }
    }
}

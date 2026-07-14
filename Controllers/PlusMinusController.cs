using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data; 
using IPOApi.Services;

namespace IPOApi.Controllers
{
    public class PlusMinusController : Controller
    {
        private IConfiguration _configuration;
        public PlusMinusController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        string constring = "";
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("FetchPlusMinus")]
        public IActionResult FetchPlusMinus(string ipo_code)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            DataSet response = new DataSet();
            try
            {
                response = PlusMinusService.FetchPlusMinus(constring, ipo_code);
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

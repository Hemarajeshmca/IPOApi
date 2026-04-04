using IPOApi.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace IPOApi.Controllers
{
    public class BidUpiController : Controller
    {
        private IConfiguration _configuration;
        public BidUpiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        string constring = "";

        [HttpGet("getBidUpi")]
        public IActionResult getBidUpi(string offer_code)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            DataTable response = new DataTable();
            try
            {
                response = BidUpiService.GetbidUpiService(offer_code, constring);
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

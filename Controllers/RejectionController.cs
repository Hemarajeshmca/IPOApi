using IPOApi.Models;
using IPOApi.Services;
using IPOApi.STADataAccess;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace IPOApi.Controllers
{
    public class RejectionController : Controller
    {
        private IConfiguration _configuration;
        public RejectionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        string constring = "";

        [HttpGet("getRejReason")]
        public IActionResult getRejReason(string offer_code)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            DataTable response = new DataTable();
            try
            {
                response = RejectionService.GetRejService(offer_code, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }

        }

        [HttpGet("GetRejectiondetail")]
        public IActionResult GetRejectiondetail(string offer_code, string rule_code)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            DataTable response = new DataTable();
            try
            {
                response = RejectionService.GetRejdetailService(offer_code, rule_code, constring);
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

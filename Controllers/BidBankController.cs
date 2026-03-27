using IPOApi.Models;
using IPOApi.Services;
using IPOApi.STADataAccess;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace IPOApi.Controllers
{
    public class BidBankController : Controller
    {
            private IConfiguration _configuration;
            public BidBankController(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            string constring = "";

        [HttpGet("GetbidBank")]
        public IActionResult GetbidBank(string offer_code)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            DataTable response = new DataTable();
            try
            {
                response = BidBankService.GetbidBankService(offer_code, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }

        }

        [HttpGet("GetbidBankdetail")]
        public IActionResult GetbidBankdetail(string offer_code, string bank_code)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            DataTable response = new DataTable();
            try
            {
                response = BidBankService.GetbidBankdetailService(offer_code, bank_code, constring);
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

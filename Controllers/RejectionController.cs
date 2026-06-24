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
        public IActionResult getRejReason(string offer_code, bool runRule)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            DataTable response = new DataTable();
            try
            {
                response = RejectionService.GetRejService(offer_code, runRule, constring);
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

        // runRejection
        [HttpGet("runRejection")]
        public IActionResult runRejection(string offer_code)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            DataTable response = new DataTable();
            try
            {
                response = RejectionService.runRejectionService(offer_code, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }

        }

        [HttpGet("GetAddRejList")]
        public IActionResult GetAddRejList(string ipo_code)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            DataSet response = new DataSet();
            try
            {
                response = RejectionService.GetAddRejService(ipo_code, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("saveAddRejDetails")]
        public IActionResult saveAddRejDetails([FromBody] RejectionModel insObj)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            DataSet response = new DataSet();
            try
            {
                response = RejectionService.saveaddrejdetails(insObj, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }

        }

        [HttpPost("Getrulecode")]
        public IActionResult Getrulecode(string ipo_code)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            DataSet response = new DataSet();
            try
            {
                response = RejectionService.Getrulecode(constring, ipo_code);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
                //return Ok(response.Tables[0]);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }


    }
}

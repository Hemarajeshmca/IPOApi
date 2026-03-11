using IPOApi.Models;
using IPOApi.STADataAccess;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using IPOApi.STAService;

namespace IPOApi.Controllers
{
    public class IssueSetupController : Controller
    {
        private IConfiguration _configuration;
        public IssueSetupData objData = new IssueSetupData();
        public IssueSetupController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        string constring = "";    

        [HttpPost("OfferType")]
        public IActionResult OfferType([FromBody] Qcdgridread objgridread)
        {
            //int ico = 0;
            //int icount = 10 / ico;
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            headerValue header_value = new headerValue();
            DataTable response = new DataTable();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = QcdmasterService.getallqcdservice(objgridread, header_value, constring);
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

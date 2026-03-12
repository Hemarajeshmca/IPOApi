using IPOApi.Models;
using IPOApi.Services;
using IPOApi.STADataAccess;
using IPOApi.STAService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using static IPOApi.Models.UtilityModel;
using static IPOApi.Models.IssueSetupModel;

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

        [HttpPost("Get_Offerlist")]
        public IActionResult Get_Offerlist()
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();

            headerValue header_value = new headerValue();
            DataSet response = new DataSet();

            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = IssueSetupService.Get_Offerlist(header_value, constring);

                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("Get_OfferFetch")]
        public IActionResult Get_OfferFetch(string client_code)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();

            headerValue header_value = new headerValue();
            DataSet response = new DataSet();

            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = IssueSetupService.Get_OfferFetch(client_code, header_value, constring);

                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("Set_OfferHeader")]
        public IActionResult Set_OfferHeader(OfferHeaderModel offerheader)
        {
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
                response = IssueSetupService.setoffer_header(offerheader, header_value, constring);
                if (response == null || response.Rows.Count == 0)
                    return NotFound("No records found"); 

                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("Set_OfferDetail")]
        public IActionResult Set_OfferDetail(OfferDetailModel offerdetail)
        {
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
                response = IssueSetupService.Set_OfferDetail(offerdetail, header_value, constring);
                if (response == null || response.Rows.Count == 0)
                    return NotFound("No records found");

                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("Set_OfferBankers")]
        public IActionResult Set_OfferBankers(OfferBankerModel offerdetail)
        {
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
                response = IssueSetupService.Set_OfferBankers(offerdetail, header_value, constring);
                if (response == null || response.Rows.Count == 0)
                    return NotFound("No records found");

                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }
    }
}

using IPOApi.Services;
using IPOApi.STADataAccess;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace IPOApi.Controllers
{
    public class AuditTrialController : Controller
    {
        private IConfiguration _configuration;
        public AuditTrialData objData = new AuditTrialData();
        public AuditTrialController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        string constring = "";

        [HttpGet("GetAuditReportTrail")]
        public IActionResult GetAuditReportTrail(string list, string sdate, string edate)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            DataSet response = new DataSet();
            try
            {
                response = AuditTrialService.GetAuditReportTrailService(list,sdate,edate, constring);
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

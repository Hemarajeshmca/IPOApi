using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using IPOApi.Models;
using IPOApi.STADataAccess;
using IPOApi.STAService;
using IPOApi.Services;


namespace IPOApi.Controllers
{
    public class RulemasterController : Controller
    {
        private IConfiguration _configuration;
        public RulemasterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        string constring = "";
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("getallRulemaster")]
        public IActionResult getallRulemaster(string ipo_code)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            DataSet response = new DataSet();
            try
            {
                response = RuleMasterService.Getrulecode(constring, ipo_code);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
                //return Ok(response.Tables[0]);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost]
        [Route("SaveAppliedRules")]
        public IActionResult SaveAppliedRules([FromBody] RuleSaveModel model)
        {
            try
            {
                constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();

                if (model == null)
                {
                    return BadRequest("Invalid Request");
                }
                 

                RuleMasterService.SaveAppliedRules(model, constring);

                return Ok(new
                {
                    success = true,
                    message = "Rules saved successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

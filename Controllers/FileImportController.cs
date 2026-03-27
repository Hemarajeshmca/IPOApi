using IPOApi.STADataAccess;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace IPOApi.Controllers
{
    public class FileImportController : Controller
    {
        private IConfiguration _configuration;
        public FileImportData objData = new FileImportData();
        public FileImportController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        string constring = "";


        [HttpPost("BankDetails")]
        public IActionResult BankDetails()
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            DataSet response = new DataSet();
            try
            {
                response = objData.getBank(constring);
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

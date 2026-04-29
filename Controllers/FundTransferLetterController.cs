using IPOApi.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace IPOApi.Controllers
{
    public class FundTransferLetterController : Controller
    {
        private IConfiguration _configuration;
        public FundTransferLetterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        string constring = "";

          [HttpGet("getBankFundDetails")]
        public IActionResult getBankFundDetails(string offer_code)
        {
            try
            {
                constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();

                var ds = FundTransferLetterService.GetBankDetailService(offer_code, constring);

                var nsbsummary = ConvertToList<NSBBankData>(ds.Tables[0]);
                var sbsummary = ConvertToList<SBBankData>(ds.Tables[1]);
                var banker = ConvertToList<BankerData>(ds.Tables[2]);

                return Ok(new
                {
                    nsbsummary,
                    sbsummary,
                    banker
                });
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpGet("Export_allotment")]
        public IActionResult Export_allotment(string offer_code)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            DataSet response = new DataSet();
            try
            {
                response = FundTransferLetterService.Export_allotment(offer_code, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        private List<T> ConvertToList<T>(DataTable dt)
        {
            var json = JsonConvert.SerializeObject(dt);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public class NSBBankData
        {
            public string bank_code { get; set; }
            public string bank_name { get; set; }
            public string client_name { get; set; }
            public long nsb_total_amount { get; set; }
            public long nsb_allocated_block_amount { get; set; }
            public long nsb_unblocked_amount { get; set; }
        }

        public class SBBankData
        {
            public string bank_code { get; set; }
            public string bank_name { get; set; }
            public string client_name { get; set; }
            public long sb_total_amount { get; set; }
            public long sb_allocated_block_amount { get; set; }
            public long sb_unblocked_amount { get; set; }
        }

        public class BankerData
        {
            public string bank_code { get; set; }
            public string bank_name { get; set; }
            public string banker_address { get; set; }
            public string banker_accountno { get; set; }
            public string banker_ifsc { get; set; }
        }
    }
}


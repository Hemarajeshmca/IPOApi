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

        [HttpGet("getBankDetails")]
        public IActionResult getBankDetails(string offer_code)
        {
            try
            {
                constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();

                var ds = BidBankService.GetBankDetailService(offer_code, constring);

                var summary = ConvertToList<BankData>(ds.Tables[0]);
                var banker = ConvertToList<BankerData>(ds.Tables[1]);

                return Ok(new
                {
                    summary,
                    banker
                });
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        // getdetaildifferenceSummary

        [HttpGet("getdetaildifferenceSummary")]
        public IActionResult getdetaildifferenceSummary(string offer_code, string user_code)
        {
            DataSet response = new DataSet();
            try
            {
                constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();

                response = BidBankService.getdetaildifferenceService(offer_code, user_code, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
                //var difference = ConvertToList<BankerData>(ds.Tables[1]);
                //return Ok(new{difference});
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

        public class BankData
        {
            public string bank_code { get; set; }
            public string bank_name { get; set; }
            public string client_name { get; set; }
            public long total_amount { get; set; }
            public long allocated_block_amount { get; set; }
            public long unblocked_amount { get; set; }
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

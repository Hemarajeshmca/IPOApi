using IPOApi.Models;
using IPOApi.STADataAccess;
using System.Data;

namespace IPOApi.Services
{
    public class BidBankService
    {
        public static DataTable GetbidBankService(string offer_code, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                BidBankData objDS = new BidBankData();
                ds = objDS.GetbidBankData(offer_code, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
    }
}

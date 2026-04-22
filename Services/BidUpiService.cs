using IPOApi.Models;
using IPOApi.STADataAccess;
using System.Data;

namespace IPOApi.Services
{
    public class BidUpiService
    {
        public static DataTable GetbidUpiService(string offer_code, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                BidUpiData objDS = new BidUpiData();
                ds = objDS.GetbidUpiData(offer_code, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable getBidUpidetailService(string offer_code, string bank_code, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                BidUpiData objDS = new BidUpiData();
                ds = objDS.getBidUpidetailData(offer_code, bank_code, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

    }
}

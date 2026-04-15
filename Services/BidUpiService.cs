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
       
    }
}

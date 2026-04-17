using IPOApi.Models;
using IPOApi.STADataAccess;
using System.Data;

namespace IPOApi.Services
{
    public class RejectionService
    {
        public static DataTable GetRejService(string offer_code, bool runRule, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                RejectionData objDS = new RejectionData();
                ds = objDS.GetRejData(offer_code, runRule, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable GetRejdetailService(string offer_code, string bank_code, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                RejectionData objDS = new RejectionData();
                ds = objDS.GetRejdetailData(offer_code, bank_code, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        // runRejectionService
        public static DataTable runRejectionService(string offer_code, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                RejectionData objDS = new RejectionData();
                ds = objDS.runRejectionData(offer_code, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

    }
}

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

        public static DataTable GetbidBankdetailService(string offer_code,string bank_code, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                BidBankData objDS = new BidBankData();
                ds = objDS.GetbidBankdetailData(offer_code, bank_code, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataSet GetBankDetailService(string offer_code, string constring)
        {
            BidBankData objDS = new BidBankData();
            return objDS.GetBankDetailData(offer_code, constring);
        }

        // getdetaildifferenceSummary

        public static DataSet getdetaildifferenceService(string offer_code, string user_code, string constring)
        {
            BidBankData objDS = new BidBankData();
            return objDS.getdetaildifferenceData(offer_code, user_code, constring);
        }
    }
}

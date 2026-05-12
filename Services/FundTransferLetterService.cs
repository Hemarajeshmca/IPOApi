using IPOApi.Models;
using IPOApi.STADataAccess;
using System.Data;

namespace IPOApi.Services
{
    public class FundTransferLetterService
    {

        public static DataSet GetBankDetailService(string offer_code, string constring)
        {
            FundTransferLetterData objDS = new FundTransferLetterData();
            return objDS.GetBankDetailData(offer_code, constring);
        }
        public static DataSet Export_allotment(string offer_code, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                FundTransferLetterData objDS = new FundTransferLetterData();
                ds = objDS.Export_allotment(offer_code, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataSet Fund_Transfer_bank_details(string offer_code, string constring)
        {
            FundTransferLetterData objDS = new FundTransferLetterData();
            return objDS.Fund_Transfer_bank_details(offer_code, constring);
        }

    }
}

using IPOApi.Models;
using IPOApi.STADataAccess;
using System.Data;

namespace IPOApi.Services
{
    public class BOAService
    {
        public static DataTable GetBoaService(string offer_code, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                BOAData objDS = new BOAData();
                ds = objDS.GetBoaData(offer_code, constring);
            }
            catch (Exception e)
            { }
            return ds;        }

        public static DataSet GetboaReportService(string offer_code, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                BOAData objDS = new BOAData();
                ds = objDS.GetboaReportData(offer_code, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }                  


        public static DataSet GetMomReportService(string offer_code, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                BOAData objDS = new BOAData();
                ds = objDS.GetMomReportData(offer_code,constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
    }
}

using IPOApi.Models;
using IPOApi.STADataAccess;
using System.Data;
using static IPOApi.Models.BOAModel;

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

        public static DataSet Export_allotment_bo(string offer_code, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                BOAData objDS = new BOAData();
                ds = objDS.Export_allotment_bo(offer_code, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
        // InsertJobService
        public static DataSet InsertJobService(insertJobModel objinsertjob, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                BOAData objDS = new BOAData();
                ds = objDS.InsertJobData(objinsertjob, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        // UpdateJobService
        public static DataSet UpdateJobService(updateJobModel objupdatejob, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                BOAData objDS = new BOAData();
                ds = objDS.UpdateJobData(objupdatejob, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

    }
}

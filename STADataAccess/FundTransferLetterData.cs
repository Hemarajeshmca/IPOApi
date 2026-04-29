using IPOApi.Models;
using System.Data;

namespace IPOApi.STADataAccess
{
    public class FundTransferLetterData
    {
        DataSet ds = new DataSet();
        List<IDbDataParameter>? parameters;
        CommonHeader objlog = new CommonHeader();
        string constring1 = "";
        DataTable result = new DataTable();

        public DataSet GetBankDetailData(string offer_code, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                DBManager dbManager = new DBManager(constring);

                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("p_offer_code", offer_code, DbType.String));

                ds = dbManager.execStoredProcedure(
                    "pr_get_bank_pdf_details",
                    CommandType.StoredProcedure,
                    parameters.ToArray()
                );

                return ds; // ✅ return full dataset
            }
            catch (Exception ex)
            {
                new CommonHeader().logger("SP Error: " + ex.Message);
                return ds;
            }
        }
        public DataSet Export_allotment(string offer_code, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_ipo_code", offer_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_ipo_get_finalAllotment", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_ipo_get_finalAllotment" + "Error Message:" + ex.Message);
                return null;
            }
        }

    }
}

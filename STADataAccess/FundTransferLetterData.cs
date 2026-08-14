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

        // GetBankDetaildownloadData
        public DataSet GetBankDetaildownloadData(string offer_code, string bank_code, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                DBManager dbManager = new DBManager(constring);

                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("p_offer_code", offer_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_bank_code", bank_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_bank_pdf_details_download", CommandType.StoredProcedure,parameters.ToArray());
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

        public DataSet Fund_Transfer_bank_details(string offer_code, string bank_code, string constring)
        {
            DataSet ds = new DataSet();
            DataSet dsloop = new DataSet();
            DataTable finalTable = new DataTable();
            DataSet finalDataSet = new DataSet();
            try
            {
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_ipo_code", offer_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_bank_code", bank_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_flag", "code", DbType.String));

                ds = dbManager.execStoredProcedure("pr_get_bank_pdf_list",CommandType.StoredProcedure,parameters.ToArray());
                // CHECK TABLE EXISTS
                if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    return finalDataSet;
                }
                string bankcode = "";
                string bank_name = "";
                // LOOP ALL BANK CODES
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    bankcode = ds.Tables[0].Rows[i]["BankCode"].ToString();
                    bank_name = ds.Tables[0].Rows[i]["bank_name"].ToString();
                    parameters = new List<IDbDataParameter>();
                    parameters.Add(dbManager.CreateParameter("in_ipo_code", offer_code, DbType.String));
                    parameters.Add(dbManager.CreateParameter("in_bank_code", bankcode, DbType.String));
                    parameters.Add(dbManager.CreateParameter("in_flag", "all", DbType.String));
                    dsloop = dbManager.execStoredProcedure("pr_get_bank_pdf_list",CommandType.StoredProcedure, parameters.ToArray());
                    // MERGE DATA
                    if (dsloop.Tables.Count > 0 &&
                        dsloop.Tables[0].Rows.Count > 0)
                    {                   
                        DataTable dt = dsloop.Tables[0].Copy();
                        dt.TableName = bank_name;
                        finalDataSet.Tables.Add(dt);
                    }
                }
                return finalDataSet; // ✅ return full dataset
            }
            catch (Exception ex)
            {
                new CommonHeader().logger("SP Error:pr_get_bank_pdf_list  " + ex.Message);
                return finalDataSet;
            }
        }

    }
}

using System.Data;

namespace IPOApi.STADataAccess
{
    public class EmailData
    {
        DataSet ds = new DataSet();
        List<IDbDataParameter>? parameters;
        CommonHeader objlog = new CommonHeader();
        string constring1 = "";
        DataTable result = new DataTable();

        public DataTable SendIpoEmailsData(string offer_code, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_reference_no", offer_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_email_list", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_email_list" + "Error Message:" + ex.Message);
                return result;
            }
        }

        public void UpdateEmailStatus(string offerCode,int gid,string status,string errorMessage,string constring)
            {
                try
                {
                    DBManager dbManager = new DBManager(constring);

                    parameters = new List<IDbDataParameter>();

                    parameters.Add(dbManager.CreateParameter("in_refernce_no", offerCode, DbType.String));
                    parameters.Add(dbManager.CreateParameter("in_gid", gid, DbType.Int32));
                    parameters.Add(dbManager.CreateParameter("in_status", status, DbType.String));
                    parameters.Add(dbManager.CreateParameter("in_error", errorMessage, DbType.String));
                    dbManager.execStoredProcedure("pr_update_ipo_email_log",CommandType.StoredProcedure,parameters.ToArray());
                }
                catch (Exception ex)
                {
                    CommonHeader objlog = new CommonHeader();
                    objlog.logger("SP:pr_update_ipo_email_log Error:" + ex.Message);
                }
        }
    }
}

using IPOApi.Models;
using System.Data;

namespace IPOApi.STADataAccess
{
    public class RejectionData
    {
        DataSet ds = new DataSet();
        List<IDbDataParameter>? parameters;
        CommonHeader objlog = new CommonHeader();
        string constring1 = "";
        DataTable result = new DataTable();

        public DataTable GetRejData(string offer_code, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_reference_no", offer_code, DbType.String));              
                ds = dbManager.execStoredProcedure("pr_ipo_get_rejection_count", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_ipo_get_rejection" + "Error Message:" + ex.Message);
                return result;
            }
        }

        public DataTable GetRejdetailData(string offer_code, string rule_code, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_reference_no", offer_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_rule_code", rule_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_bid_bank_recon_detail_new", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_bid_bank_recon_detail" + "Error Message:" + ex.Message);
                return result;
            }
        }

    }
}

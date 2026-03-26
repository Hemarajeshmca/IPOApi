using IPOApi.Models;
using System.Data;

namespace IPOApi.STADataAccess
{
    public class BidBankData
    {
        DataSet ds = new DataSet();
        List<IDbDataParameter>? parameters;
        CommonHeader objlog = new CommonHeader();
        string constring1 = "";
        DataTable result = new DataTable();

        public DataTable GetbidBankData(string offer_code, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("ipo_code", offer_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_bid_bank_recon", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_bid_bank_recon" + "Error Message:" + ex.Message);
                return result;
            }
        }

    }
}

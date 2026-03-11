using System.Data;
using MySql.Data.MySqlClient;
using IPOApi.Models;
using static System.Net.WebRequestMethods;

namespace IPOApi.STADataAccess
{
    public class IssueSetupData
    {
        DataSet ds = new DataSet();
        List<IDbDataParameter>? parameters;
        CommonHeader objlog = new CommonHeader();
        string constring1 = "";
        public DataSet getofferType(IssueSetupModel inscObj, string constring)
        {

            try
            {
                constring1 = constring;
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("p_master_code", inscObj.mastercode, DbType.String));
                parameters.Add(dbManager.CreateParameter("p_depend_value", inscObj.dependvalue, DbType.String));
                ds = dbManager.execStoredProcedurelist("pr_get_masterlist", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                // Log error if any
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:sp_get_masterlist" + " Error Message:" + ex.Message);
            }

            return ds; // Return the DataSet with results
        }


    }
}

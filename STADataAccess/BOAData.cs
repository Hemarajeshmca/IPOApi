using IPOApi.Models;
using System.Data;

namespace IPOApi.STADataAccess
{
    public class BOAData
    {
        DataSet ds = new DataSet();
        List<IDbDataParameter>? parameters;
        CommonHeader objlog = new CommonHeader();
        string constring1 = "";
        DataTable result = new DataTable();

        public DataTable GetBoaData(string offer_code, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_ipo_code", offer_code, DbType.String));              
                ds = dbManager.execStoredProcedure("pr_generate_lottery", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_generate_lottery" + "Error Message:" + ex.Message);
                return result;
            }
        }

      

    }
}

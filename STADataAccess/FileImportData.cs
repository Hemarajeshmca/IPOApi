using IPOApi.Models;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System.Data;
using static System.Net.WebRequestMethods;

namespace IPOApi.STADataAccess
{
    public class FileImportData
    {
        DataSet ds = new DataSet();
        List<IDbDataParameter>? parameters;
        CommonHeader objlog = new CommonHeader();
        string constring1 = "";        
        DataTable result = new DataTable();

        public DataSet getBank(string constring)
        {

            try
            {
                constring1 = constring;
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                ds = dbManager.execStoredProcedurelist("pr_get_all_banknames", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                // Log error if any
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_all_banknames" + " Error Message:" + ex.Message);
            }

            return ds; // Return the DataSet with results
        }

    }
}

using System.Data;
using IPOApi.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using MySqlX.XDevAPI.Common;

namespace IPOApi.STADataAccess
{
    public class ConfigurationData
    {
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        List<IDbDataParameter>? parameters;
        public DataTable fetchconfigData(string constring)
        {

            List<IDbDataParameter> parameters = new List<IDbDataParameter>();

            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();

                parameters = new List<IDbDataParameter>();
                ds = dbManager.execStoredProcedure("pr_fetch_config", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];

                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_fetch_config" + "Error Message:" + ex.Message);
                //objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objgridread), "pr_get_allqcdmaster", headerval.user_code, constring);
                return result;
            }
        }

        public DataTable UpdateConfig(string json,string constring)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            DataTable result = new DataTable();
            try
            {
                DBManager dbManager = new DBManager(constring);

                parameters.Add(dbManager.CreateParameter("in_json",json,DbType.String));               
                DataSet ds = dbManager.execStoredProcedure("pr_upd_config",CommandType.StoredProcedure,parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger( "SP:pr_upd_config Error Message:"+ ex.Message);
                return result;
            }
        }
    }
}
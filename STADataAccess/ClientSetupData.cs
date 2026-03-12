using IPOApi.Models;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System.Data;
using static System.Net.WebRequestMethods;

namespace IPOApi.STADataAccess
{
    public class ClientSetupData
    {
        DataSet ds = new DataSet();
        List<IDbDataParameter>? parameters;
        CommonHeader objlog = new CommonHeader();
        string constring1 = "";        
        DataTable result = new DataTable();
        
        public DataTable getclientType(Qcdgridread objgridread, headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess(objgridread.in_user_code);
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_master_code", objgridread.in_master_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_allqcdmaster", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_allqcdmaster" + "Error Message:" + ex.Message);
                //objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objgridread), "pr_get_allqcdmaster", headerval.user_code, constring);
                return result;
            }
        }

        public DataSet IudClient(clientDetails insObj, string constring)
        {
            try
            {

                constring1 = constring;
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_client_gid", insObj.in_client_gid, DbType.Int32));
                parameters.Add(dbManager.CreateParameter("in_client_name", insObj.in_client_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_client_type", insObj.in_client_type, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_client_cin", insObj.in_client_cin, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_client_contact_person", insObj.in_client_contact_person, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_client_mob_no", insObj.in_client_mob_no, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_client_email_id", insObj.in_client_email_id, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_client_addr", insObj.in_client_addr, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_client_country", insObj.in_client_country, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_client_state", insObj.in_client_state, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_client_city", insObj.in_client_city, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_client_pincode", insObj.in_client_pincode, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_insert_by", insObj.in_insert_by, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_update_by", insObj.in_update_by, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", insObj.in_action, DbType.String));                
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedurelist("pr_iud_client", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_iud_client" + "Error Message:" + ex.Message);
            }
            return ds;
        }

        public DataSet getclientlist(clientList insObj, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>(); // if no params, leave empty
                parameters.Add(dbManager.CreateParameter("p_action", insObj.p_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("p_client_gid", insObj.p_client_gid, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedurelist("pr_get_tclientdetails", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_tclientdetails Error Message: " + ex.Message);
            }

            return ds;
        }
    }
}

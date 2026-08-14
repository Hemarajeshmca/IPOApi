using System.Data;
using MySql.Data.MySqlClient;
using IPOApi.Models;
using static System.Net.WebRequestMethods;

namespace IPOApi.STADataAccess
{
    public class LoginData
    {
        DataSet ds = new DataSet();
        List<IDbDataParameter>? parameters;
        CommonHeader objlog = new CommonHeader();
        public DataSet setCredentials(string email,string otp,string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_user_email", email, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_otp", otp, DbType.String));
                ds = dbManager.execStoredProcedurelist("pr_set_employeecredentials", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_set_employeecredentials" + "Error Message:" + ex.Message);
                return ds;
            }

        }

		public DataSet validateCredentials(string empcode, string otp, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_empcode", empcode, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_otp", otp, DbType.String));
				ds = dbManager.execStoredProcedurelist("pr_get_validatecredentials", CommandType.StoredProcedure, parameters.ToArray());
				return ds;
			}
			catch (Exception ex)
			{
				CommonHeader objlog = new CommonHeader();
				objlog.logger("SP:pr_get_validatecredentials" + "Error Message:" + ex.Message);
				return ds;
			}

		}

        public DataSet GetMenu(Int16 userGroupid, string menutype, Int16 menu_gid, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_usergroup_gid", userGroupid, DbType.Int16));
                parameters.Add(dbManager.CreateParameter("menu_type", menutype, DbType.String));
                parameters.Add(dbManager.CreateParameter("menu_gid", menu_gid, DbType.Int16));
                ds = dbManager.execStoredProcedurelist("SP_Getmenu", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:SP_Getmenu" + "Error Message:" + ex.Message);
                return ds;
            }
        }

        public DataSet chngpwd(LoginModel Obj, string constring)
        {

            try
            {
                //throw new Exception("Log4net test error");

                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_empcode", Obj.empcode, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_oldpwd", Obj.old_pwd, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_newpwd", Obj.new_pwd, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_conpwd", Obj.con_pwd, DbType.String));

                ds = dbManager.execStoredProcedurelist("pr_upd_pwd", CommandType.StoredProcedure, parameters.ToArray());

            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_upd_pwd - ChangePassword - Method Name " + "Error Message:" + ex.Message);
                throw;

            }
            return ds;
        }

        public DataSet getchngpwdflag(LoginModel iudObj, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_user_code", iudObj.empcode, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_pwd", iudObj.txt_pwd, DbType.String));

                ds = dbManager.execStoredProcedurelist("pr_GNSA_Login_Validate", CommandType.StoredProcedure, parameters.ToArray());
                getLogindetails(iudObj, constring, "SUCCESS","");
                return ds;
            }
            catch (Exception ex)
            {

                objlog.logger("SP:pr_GNSA_Login_Validate - Method Name " + "Error Message:" + ex.Message);
                getLogindetails(iudObj, constring, "FAILED", ex.Message);
                return ds;
            }

        }

        public DataSet getLogindetails(LoginModel iudObj, string constring,string login_action,string msg)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_user_code", iudObj.empcode, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_login_date", DateTime.Now, DbType.String));                
                parameters.Add(dbManager.CreateParameter("in_login_status", login_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_failure_reason", msg, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_address", iudObj.ipaddress, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_browser_name", iudObj.browseragent, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_session_id", iudObj.LoginSessionId, DbType.String));

                ds = dbManager.execStoredProcedurelist("pr_ins_loginlog", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {

                objlog.logger("SP:pr_ins_loginlog - Method Name " + "Error Message:" + ex.Message);
                return ds;
            }

        }
    }
}

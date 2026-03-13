using IPOApi.Models;
using IPOApi.STADataAccess;
using Newtonsoft.Json;
using System.Data;
using static IPOApi.Models.CommonModel;

namespace IPOApi.STADataAccess
{
	public class CommonHeader
	{
		DataSet ds = new DataSet();
		DataTable result = new DataTable();
		List<IDbDataParameter>? parameters;
		string constring1 = "";
		public DataTable commonData(errorlogModel objerrorlog, string constring)
		{
			try
			{
				constring1 = constring;
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_ip_addr", objerrorlog.in_ip_addr, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_source_name", objerrorlog.in_source_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_errorlog_text", objerrorlog.in_errorlog_text, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_proc_name", objerrorlog.in_proc_name, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", objerrorlog.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
				parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
				ds = dbManager.execStoredProcedure("pr_ins_errorlog", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{

				return result;
			}
		}

        public DataTable configvalueData(configvalueModel objconfigvalue, UserManagementModel.headerValue hv, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_config_name", objconfigvalue.in_config_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_config_value", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_get_configvalue", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                logger("SP:pr_get_configvalue" + " " + "Error Message:" + ex.Message);
                return result;
            }
        }
        public DataTable reconmindate_db(reconmindate objconfigvalue, UserManagementModel.headerValue hv, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objconfigvalue.in_recon_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_recon_mindate", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                logger("SP:pr_get_recon_mindate" + " " + "Error Message:" + ex.Message);
                return result;
            }
        }

        public DataTable archivaldatasetsave_db(archivaldatasetsaveModel Objmodel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_archivaldataset_gid", Objmodel.in_archivaldataset_gid, DbType.Int32, ParameterDirection.InputOutput));
                parameters.Add(dbManager.CreateParameter("in_archivaldatasetfilter_gid", Objmodel.in_archivaldatasetfilter_gid, DbType.Int32));
                parameters.Add(dbManager.CreateParameter("in_dataset_code", Objmodel.in_dataset_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_code", Objmodel.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_dataset_type", Objmodel.in_dataset_type, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_archival_flag", Objmodel.in_archival_flag, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_filter_seqno", Objmodel.in_filter_seqno, DbType.Double));
                parameters.Add(dbManager.CreateParameter("in_filter_field", Objmodel.in_filter_field, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_filter_criteria", Objmodel.in_filter_criteria, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_filter_value_flag", Objmodel.in_filter_value_flag, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_filter_value", Objmodel.in_filter_value, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_open_parentheses_flag", Objmodel.in_open_parentheses_flag, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_close_parentheses_flag", Objmodel.in_close_parentheses_flag, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_join_condition", Objmodel.in_join_condition, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_active_status", Objmodel.in_active_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", Objmodel.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action_by", Objmodel.in_user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_recon_mst_tarchivaldataset", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_recon_mst_tarchivaldataset" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(Objmodel), "pr_recon_mst_tarchivaldataset", headerval.user_code, constring);
                return result;
            }
        }

        public DataTable Archeivedatasetfetch_db(ArcheivedatasetfetchModel objconfigvalue, UserManagementModel.headerValue hv, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objconfigvalue.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_dataset_code", objconfigvalue.in_dataset_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_archivaldatasetfetch", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                logger("SP:pr_get_archivaldatasetfetch" + " " + "Error Message:" + ex.Message);
                return result;
            }
        }
        public DataTable Archeivedatasetlist_db(ArcheivedatasetlistModel objconfigvalue, UserManagementModel.headerValue hv, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objconfigvalue.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", hv.user_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_archivaldatasetlist", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                logger("SP:pr_get_archivaldatasetlist" + " " + "Error Message:" + ex.Message);
                return result;
            }
        }

        public DataTable reportconfig_db(reportvalidatemodel objconfigvalue, UserManagementModel.headerValue hv, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objconfigvalue.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_rpttemplate_code", objconfigvalue.in_template_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_role_code", hv.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", "RC006", DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_report_permission_config", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                logger("SP:pr_get_role_config" + " " + "Error Message:" + ex.Message);
                return result;
            }
        }
        public DataTable roleconfig_db(roleconfig objconfigvalue, UserManagementModel.headerValue hv, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_screen_code", objconfigvalue.in_screen_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", hv.role_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_role_config", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                logger("SP:pr_get_role_config" + " " + "Error Message:" + ex.Message);
                return result;
            }
        }
        public DataTable commonDataapi(string ipaddr, string sourcename, string errorlog, string procname, string usrcode, string constring)
        {
            try
            {
                constring1 = constring;
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_ip_addr", ipaddr, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_source_name", sourcename, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_errorlog_text", errorlog, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_proc_name", procname, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", usrcode, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_ins_errorlog", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {

                return result;
            }
        }
        public void logger(string sMessage)
		{
            //string logFilePath = "E:\\Mangai\\GNSA\\Registration\\IPOApi\\Logs\\error.log"; // "D:\\DMS Error Log\\error.log";
            string logFilePath = "D:\\Billing\\STABillingAPI\\Logs\\error.log";
            string[] parts = sMessage.Split(new string[] { "SP:", "Message:" }, StringSplitOptions.None);
			string result = parts[1].Trim();
			errorlogModel objmodel = new errorlogModel();
			objmodel.in_proc_name = parts[1].Trim();
			objmodel.in_errorlog_text = parts[2].Trim();
			objmodel.in_ip_addr = "localhost";
			objmodel.in_source_name = "SP";
			objmodel.user_code = "STA";
			commonData(objmodel, constring1);
			// Ensure the directory exists
			string logDirectory = Path.GetDirectoryName(logFilePath);
			if (!Directory.Exists(logDirectory))
			{
				Directory.CreateDirectory(logDirectory);
			}

			// Append the error information to the log file
			using (StreamWriter writer = new StreamWriter(logFilePath, true))
			{
				writer.WriteLine($"Timestamp: {DateTime.Now}");

				writer.WriteLine($"Message: {sMessage}");
				writer.WriteLine(new string('-', 40)); // Separator between entries
			}
		}
	}
}

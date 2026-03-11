using IPOApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IPOApi.Models.UtilityModel;

namespace IPOApi.STADataAccess
{
	public class UtilityData
	{
		DataSet ds = new DataSet();
		DataTable result = new DataTable();		
		List<IDbDataParameter>? parameters;

		public DataTable jobstatusData(JobStatusList objobstatus, headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_start_date", objobstatus.in_start_date, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_end_date", objobstatus.in_end_date, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_jobtype_code", objobstatus.in_jobtype_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_jobstatus", objobstatus.in_jobstatus, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_jobstatus", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_jobstatus" + "Error Message:" + ex.Message);
				// objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objobstatus), "pr_get_jobstatus", headerval.user_code, constring);
				return result;
			}
		}
		

		public DataTable jobtypeData(headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_recon_jobtype", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_recon_jobtype" + "Error Message:" + ex.Message);
				// objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(headerval), "pr_get_recon_jobtype", headerval.user_code, constring);
				return result;
			}
		}

		public DataTable objJobCompletedData(JobCompleted objJobCompleted, headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_start_date", objJobCompleted.in_start_date, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_end_date", objJobCompleted.in_end_date, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_jobtype_code", objJobCompleted.in_jobtype_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", objJobCompleted.in_user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_jobcompleted", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_jobcompleted" + "Error Message:" + ex.Message);
				// objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objJobCompleted), "pr_get_jobcompleted", headerval.user_code, constring);
				return result;
			}
		}

		public DataTable jobinpogressData(JobCompleted objJobCompleted, headerValue headerval, string constring)
		{
			try
			{
				DBManager dbManager = new DBManager(constring);
				Dictionary<string, Object> values = new Dictionary<string, object>();
				MySqlDataAccess con = new MySqlDataAccess("");
				parameters = new List<IDbDataParameter>();
				parameters.Add(dbManager.CreateParameter("in_start_date", objJobCompleted.in_start_date, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_end_date", objJobCompleted.in_end_date, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_jobtype_code", objJobCompleted.in_jobtype_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_user_code", objJobCompleted.in_user_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
				parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
				ds = dbManager.execStoredProcedure("pr_get_jobinProgress", CommandType.StoredProcedure, parameters.ToArray());
				result = ds.Tables[0];
				return result;
			}
			catch (Exception ex)
			{
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_jobinProgress" + "Error Message:" + ex.Message);
				// objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objJobCompleted), "pr_get_jobinProgress", headerval.user_code, constring);
				return result;
			}
		}
        public DataTable jobinQueueData(JobCompleted objJobCompleted, headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_start_date", objJobCompleted.in_start_date, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_end_date", objJobCompleted.in_end_date, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_jobtype_code", objJobCompleted.in_jobtype_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", objJobCompleted.in_user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_koqueue", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_koqueue" + "Error Message:" + ex.Message);
                // objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objJobCompleted), "pr_get_koqueue", headerval.user_code, constring);
                return result;
            }
        }
        public DataTable SuspendKoQueueData(KoQueued objkoQue, headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_koqueue_gid", Convert.ToInt32(objkoQue.in_koqueue_gid), DbType.Int32));
                parameters.Add(dbManager.CreateParameter("in_koqueue_remark", objkoQue.in_koqueue_remark, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_koqueue_status", "S", DbType.String));
                var outParameter1 = dbManager.CreateParameter("out_result", null, DbType.Int32);
                outParameter1.Direction = ParameterDirection.Output;
                parameters.Add(outParameter1);
                var outParameter2 = dbManager.CreateParameter("out_msg", null, DbType.String);
                outParameter2.Direction = ParameterDirection.Output;
                parameters.Add(outParameter2);
                ds = dbManager.execStoredProcedure("pr_upd_koqueue", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_upd_koqueue" + "Error Message:" + ex.Message);
                // objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objkoQue), "pr_upd_koqueue", headerval.user_code, constring);
                return result;
            }
        }
    }
}


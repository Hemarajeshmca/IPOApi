using DocumentFormat.OpenXml.Drawing.Diagrams;
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

        public DataSet GetboaReportData(string offer_code, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_ipo_code", offer_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", "", DbType.String));
                ds = dbManager.execStoredProcedure("pr_ipo_get_boa_report", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_ipo_get_boa_report" + "Error Message:" + ex.Message);
                return ds;
            }
        }        

        public DataSet GetMomReportData(string offer_code, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("p_offer_code", offer_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_mom_reports", CommandType.StoredProcedure, parameters.ToArray());                
                return ds;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_mom_reports" + "Error Message:" + ex.Message);
                return null;
            }
        }

        public DataSet Export_allotment_bo(string offer_code, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_ipo_code", offer_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_ipo_get_finalAllotment", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_ipo_get_finalAllotment" + "Error Message:" + ex.Message);
                return null;
            }
        }
   
        public DataSet InsertJobData(insertJobModel objinsertjob, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objinsertjob.recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_jobtype_code", objinsertjob.jobtype_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_job_ref_gid", objinsertjob.job_ref_gid, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_job_name", objinsertjob.job_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_job_input_param", objinsertjob.job_input_param, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_job_initiated_by", objinsertjob.job_initiated_by, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_addr", objinsertjob.ip_addr, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_job_status", objinsertjob.job_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_job_remark", objinsertjob.job_remark, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_job_gid", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_ins_job", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_ins_job" + "Error Message:" + ex.Message);
                return null;
            }
        }

        public DataSet UpdateJobData(updateJobModel objupdatejob, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_job_gid", Convert.ToInt32(objupdatejob.in_job_gid), DbType.Int32));
                parameters.Add(dbManager.CreateParameter("in_job_status", objupdatejob.in_job_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_job_remark", objupdatejob.in_job_remark, DbType.String));                
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_upd_job", CommandType.StoredProcedure, parameters.ToArray());
                return ds;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_upd_job" + "Error Message:" + ex.Message);
                return null;
            }
        }

    }
}

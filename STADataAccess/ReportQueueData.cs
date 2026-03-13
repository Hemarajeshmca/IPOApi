using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;
using IPOApi.Models;
using IPOApi.STADataAccess;
using IPOApi.STADataAccess.Interface;

namespace ReconDataLayer
{
    public class ReportQueueData: IReportQueueData
    {
        private string constring;
        List<IDbDataParameter>? parameters;
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        public ReportQueueData(IConfiguration configuration)
        {
            constring = configuration["Appsettings:ConnectionStrings"];
        }
                                            
        public DataTable setReportqueuedata(ReportQueueModel.reportqueue report, string jsonString, UserManagementModel.headerValue headerVal)
        {
            try
            {
                // serialize to JSON string
                //string jsonString = JsonConvert.SerializeObject(report);
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_archival_code", report.in_archival_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_code", report.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_data_values", jsonString, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerVal.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_set_koqueue_report", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];                
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_set_koqueue_report" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(headerVal), "pr_set_koqueue_report", headerVal.user_code, constring);
                throw ex;
            }
            return result;
        }
        public DataTable getReportqueuedata(UserManagementModel.headerValue headerVal)
        {
            try
            {
                
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>();
                //parameters.Add(dbManager.CreateParameter("in_user_code", headerVal.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_get_koqueue_report", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];

            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_koqueue_report" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(headerVal), "pr_get_koqueue_report", headerVal.user_code, constring);
                throw ex;
            }
            return result;
        }
    }
}

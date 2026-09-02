using IPOApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
// Use fully-qualified headerValue to avoid ambiguity with other headerValue types in the project

namespace IPOApi.STADataAccess
{
    public class AuditData
    {
        public DataTable InsertAuditLog(AuditLogEntryModel model, IPOApi.Models.headerValue headerval, string constring)
        {
            DataTable result = new DataTable();
            try
            {
                DBManager dbManager = new DBManager(constring);
                List<IDbDataParameter>? parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_user_id", model.UserId ?? string.Empty, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_name", model.UserName ?? string.Empty, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_application_name", model.ApplicationName ?? string.Empty, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_controller_name", model.ControllerName ?? string.Empty, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action_method", model.ActionMethodName ?? string.Empty, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_business_action", model.BusinessActionName ?? string.Empty, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_http_method", model.HttpMethod ?? string.Empty, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_request_url", model.RequestUrl ?? string.Empty, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action_params", model.ActionParametersJson ?? string.Empty, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_ip_address", model.IpAddress ?? string.Empty, DbType.String));

                // store timestamp as ISO string to avoid DB type issues in stored proc
                parameters.Add(dbManager.CreateParameter("in_timestamp", model.Timestamp.ToString("o"), DbType.String));
                parameters.Add(dbManager.CreateParameter("in_is_success", model.IsSuccess ? "1" : "0", DbType.String));
                parameters.Add(dbManager.CreateParameter("in_exception_msg", model.ExceptionMessage ?? string.Empty, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_correlation_id", model.CorrelationId ?? string.Empty, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_status_code", model.ResponseStatusCode ?? 0, DbType.Int32));

                // caller header info consistent with other data methods
              

                // standard output params used by stored procs across the project
                parameters.Add(dbManager.CreateParameter("out_msg", "", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", 0, DbType.Int32, ParameterDirection.Output));

                var ds = dbManager.execStoredProcedure("pr_ins_auditlog", CommandType.StoredProcedure, parameters.ToArray());
                if (ds != null && ds.Tables.Count > 0)
                    result = ds.Tables[0];
            }
            catch (Exception ex)
            {
                // follow project pattern: log and swallow
                try
                {
                    CommonHeader objlog = new CommonHeader();
                    objlog.logger("SP:pr_ins_auditlog | Error: " + ex.Message);
                }
                catch { }
            }

            return result;
        }
    }
}

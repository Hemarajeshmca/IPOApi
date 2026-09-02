using IPOApi.Models;
using MySql.Data.MySqlClient;
using System.Data;
using static IPOApi.Models.IssueSetupModel;
using static IPOApi.Models.UtilityModel;
using static System.Net.WebRequestMethods;

namespace IPOApi.STADataAccess
{
    public class AuditTrialData
    { 
        DataTable result = new DataTable();  
        DataSet ds = new DataSet();
        List<IDbDataParameter>? parameters;
        CommonHeader objlog = new CommonHeader();       

        public DataSet GetAuditReportTrailData(string list, string sdate, string edate, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_action", list, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_from_date", sdate, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_to_date", edate, DbType.String));
                ds = dbManager.execStoredProcedurelist("pr_fetch_auditlog", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_fetch_auditlog Error Message: " + ex.Message);
            }
            return ds;
        }

    }
}

using IPOApi.Models;
using MySql.Data.MySqlClient;
using System.Data;
using static IPOApi.Models.IssueSetupModel;
using static IPOApi.Models.UtilityModel;
using static System.Net.WebRequestMethods;

namespace IPOApi.STADataAccess
{
    public class DashboardData
    { 
        DataTable result = new DataTable();  
        DataSet ds = new DataSet();
        List<IDbDataParameter>? parameters;
        CommonHeader objlog = new CommonHeader();
        string constring1 = "";
       

        public DataSet Get_Dashboarddetails(headerValue headerval, string constring)
        {
            DBManager dbManager = new DBManager(constring);
            parameters = new List<IDbDataParameter>();
             
            parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String)); 
            DataSet ds = dbManager.execStoredProcedure(
                "pr_get_dashboard_details",
                CommandType.StoredProcedure,
                parameters.ToArray()
            );
            return ds;
        }     
    }
}

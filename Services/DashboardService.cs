using IPOApi.Models;
using IPOApi.STADataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IPOApi.Models.IssueSetupModel;
//using static IPOApi.Models.UserManagementModel;
using static IPOApi.Models.UtilityModel;
namespace IPOApi.Services
{
    public class DashboardService
    {
        public static DataSet Get_Dashboardlist(headerValue headerval, string constring)
        {
            DataSet ds = new DataSet();

            try
            {
                DashboardData objData = new DashboardData();
                ds = objData.Get_Dashboarddetails(headerval, constring);
            }
            catch (Exception)
            {
            }

            return ds;
        }      

    }
}

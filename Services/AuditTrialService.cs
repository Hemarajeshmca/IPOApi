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
    public class AuditTrialService
    {
        public static DataSet GetAuditReportTrailService(string list,string sdate, string edate, string constring)
        {
            DataSet ds = new DataSet();

            try
            {
                AuditTrialData objData = new AuditTrialData();
                ds = objData.GetAuditReportTrailData(list,sdate,edate, constring);
            }
            catch (Exception)
            {
            }

            return ds;
        }

    }
}

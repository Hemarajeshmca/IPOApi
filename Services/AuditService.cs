using IPOApi.Models;
using IPOApi.STADataAccess;
using System.Data;
namespace IPOApi.Services
{
    public class AuditService
    {
        public static DataTable SaveAudit(AuditLogEntryModel model, IPOApi.Models.headerValue headerval, string constring)
        {
            DataTable dt = new DataTable();
            try
            {
                AuditData data = new AuditData();
                dt = data.InsertAuditLog(model, headerval, constring);
            }
            catch
            {
                // follow project convention: swallow exceptions
            }

            return dt;
        }
    }
}

using IPOApi.Models;
using System.Data;

namespace IPOApi.Services.Interface
{
    public interface IReportQueueService
    {
        public DataTable setReportqueueservice(ReportQueueModel.reportqueue report, string jsonString, UserManagementModel.headerValue headerVal);
        public DataTable getReportqueueservice(UserManagementModel.headerValue headerVal);
    }
}

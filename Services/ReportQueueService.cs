using IPOApi.Models;
using IPOApi.Services.Interface;
using IPOApi.STADataAccess.Interface;
using System.Data;
using ReconDataLayer;

namespace ReconServiceLayer
{
    public class ReportQueueService : IReportQueueService
    {
        DataTable dt = new DataTable();
        private readonly IReportQueueData _reportQueueData;

        public ReportQueueService(IReportQueueData reportQueueData)
        {
            _reportQueueData = reportQueueData;
        }
        public DataTable setReportqueueservice(ReportQueueModel.reportqueue report, string jsonString, UserManagementModel.headerValue headerVal)
        {
            try
            {
                dt = _reportQueueData.setReportqueuedata(report, jsonString, headerVal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable getReportqueueservice(UserManagementModel.headerValue headerVal)
        {
            try
            {
                dt = _reportQueueData.getReportqueuedata(headerVal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}

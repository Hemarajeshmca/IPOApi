using IPOApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconServiceLayer.Interface
{
    public interface IKillJobService
    {
        public DataTable setKillJobService(Int64 processId, string action, UserManagementModel.headerValue headerVal);
        public DataTable getKillJobService(Int64 processId, string action, UserManagementModel.headerValue headerVal);
    }
}

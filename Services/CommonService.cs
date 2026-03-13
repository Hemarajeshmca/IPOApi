using IPOApi.STADataAccess;
using IPOApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IPOApi.Models.DatasetModel;
using static IPOApi.Models.ReconModel;
using static IPOApi.Models.CommonModel;
using static IPOApi.Models.UserManagementModel;

namespace IPOApi.Services
{
	public class CommonService
	{
		public static DataTable Commonservice(errorlogModel objerrorlog, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				CommonHeader objDS = new CommonHeader();
				ds = objDS.commonData(objerrorlog, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}



		public static DataTable configvalueservice(configvalueModel objconfigvalue, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				CommonHeader objDS = new CommonHeader();
				ds = objDS.configvalueData(objconfigvalue, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable roleconfig_srv(roleconfig objconfigvalue, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				CommonHeader objDS = new CommonHeader();
				ds = objDS.roleconfig_db(objconfigvalue, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		public static DataTable reconmindate_srv(reconmindate objconfigvalue, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				CommonHeader objDS = new CommonHeader();
				ds = objDS.reconmindate_db(objconfigvalue, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
        public static DataTable reportconfig_srv(reportvalidatemodel objconfigvalue, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                CommonHeader objDS = new CommonHeader();
                ds = objDS.reportconfig_db(objconfigvalue, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable Archeivedatasetlist_srv(ArcheivedatasetlistModel objconfigvalue, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                CommonHeader objDS = new CommonHeader();
                ds = objDS.Archeivedatasetlist_db(objconfigvalue, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
        public static DataTable archivaldatasetsave_srv(archivaldatasetsaveModel objconfigvalue, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                CommonHeader objDS = new CommonHeader();
                ds = objDS.archivaldatasetsave_db(objconfigvalue, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
        public static DataTable Archeivedatasetfetch_srv(ArcheivedatasetfetchModel objconfigvalue, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                CommonHeader objDS = new CommonHeader();
                ds = objDS.Archeivedatasetfetch_db(objconfigvalue, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
    }
}

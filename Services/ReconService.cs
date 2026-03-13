using ReconDataLayer;
using IPOApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IPOApi.Models.DatasetModel;
using static IPOApi.Models.ReconModel;
using static IPOApi.Models.UserManagementModel;

namespace IPOApi.Services
{
    public class ReconService
    {
        public static DataTable getReconType(UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objqcd = new ReconData();
                ds = objqcd.recntypeData(headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable getReconList(Reconlist objreconlist, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objqcd = new ReconData();
                ds = objqcd.recnlistData(objreconlist, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataSet fetchReconDetails(fetchRecon objfetch, UserManagementModel.headerValue headerval, string constring)
        {
            //DataTable ds = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                ReconData objqcd = new ReconData();
                ds = objqcd.fetchRecondtl(objfetch, headerval, constring);

            }
            catch (Exception e)
            { }
            return ds;
        }
        public static DataTable recondatamapping(datamapping objdatamapping, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objqcd = new ReconData();
                ds = objqcd.recondatamapping(objdatamapping, headerval, constring);

            }
            catch (Exception e)
            { }
            return ds;
        }
		public static DataTable recondatafieldsrv(datafieldmodel objdatafieldmodel, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				ReconData objqcd = new ReconData();
				ds = objqcd.recondatafielddata(objdatafieldmodel, headerval, constring);

			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable recondatamappingdelete(datamapping objdatamapping, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				ReconData objqcd = new ReconData();
				ds = objqcd.recondatamappingdelete(objdatamapping, headerval, constring);

			}
			catch (Exception e)
			{ }
			return ds;
		}

		public static DataTable Recon(Recon recon, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objrecon = new ReconData();
                ds = objrecon.Recon(recon, headerval, constring);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataTable Recondataset(Recondataset objrecondataset, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objrecon = new ReconData();
                ds = objrecon.Recondatset(objrecondataset, headerval, constring);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        
        public static DataTable Recondatamappinglist(getReconDataMappingList objdatamappinglist, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objrecon = new ReconData();
                ds = objrecon.Recondatamappinglist(objdatamappinglist, headerval, constring);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

		

		public static DataTable ReconFieldAgainstReconlist(getFieldAgainstReconList objfieldlist, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				ReconData objrecon = new ReconData();
				ds = objrecon.ReconFieldAgainstReconlist(objfieldlist, headerval, constring);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return ds;
		}

        public static DataTable reconlistknockoffService(UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objrecon = new ReconData();
                ds = objrecon.reconlistknockoff(headerval, constring);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

		public static DataTable getReconagainsttypecode(Reconagainsttypecode objreconlist, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				ReconData objqcd = new ReconData();
				ds = objqcd.reconagainsttypecodeData(objreconlist, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		
		public static DataSet Datasetfield(Datasetfieldlist Datasetfieldlist, UserManagementModel.headerValue headerval, string constring)
		{
			DataSet ds = new DataSet();
			try
			{
				ReconData objDS = new ReconData();
				ds = objDS.Datasetfielddata(Datasetfieldlist, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		//cloneReconService

		public static DataTable cloneReconService(cloneReconModel objcloneRecon, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable dt = new DataTable();
			try
			{
				ReconData objDS = new ReconData();
				dt = objDS.cloneReconData(objcloneRecon, headerval, constring);
			}
			catch (Exception e)
			{ }
			return dt;
		}

		//cloneReconDatasetService

		public static DataTable cloneReconDatasetService(cloneReconDatasetModel objcloneReconDataset, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable dt = new DataTable();
			try
			{
				ReconData objDS = new ReconData();
				dt = objDS.cloneReconDatasetData(objcloneReconDataset, headerval, constring);
			}
			catch (Exception e)
			{ }
			return dt;
		}

		public static DataSet fetchCloneReconDetails(fetchRecon objfetch, UserManagementModel.headerValue headerval, string constring)
		{
			//DataTable ds = new DataTable();
			DataSet ds = new DataSet();
			try
			{
				ReconData objqcd = new ReconData();
				ds = objqcd.fetchCloneRecondtl(objfetch, headerval, constring);

			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable ReconDatasetlist( UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				ReconData objqcd = new ReconData();
				ds = objqcd.ReconDatasetlistData( headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		//getReconforOpeningBalanceService

		public static DataTable getReconforOpeningBalanceService(UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				ReconData objqcd = new ReconData();
				ds = objqcd.getReconforOpeningBalanceData(headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}

		//getdatasetagainstReconService

		public static DataTable getdatasetagainstReconService(openingbalanceDatasetModel objReconDataset, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				ReconData objqcd = new ReconData();
				ds = objqcd.getdatasetagainstReconData(objReconDataset, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable ReconDatasetmaplist_srv(fetchRecon objReconDataset, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				ReconData objqcd = new ReconData();
				ds = objqcd.ReconDatasetmaplist_db(objReconDataset, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}
        //ArcheiveReconService

        public static DataTable ArcheiveReconService(ArcheiveReconobj objArcheiveRecon, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objqcd = new ReconData();
                ds = objqcd.ArcheiveReconData(objArcheiveRecon, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable ArcheiveReconlistService(ArcheiveReconobj objArcheiveRecon, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                ReconData objqcd = new ReconData();
                ds = objqcd.ArcheiveReconlistData(objArcheiveRecon, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
    }
}

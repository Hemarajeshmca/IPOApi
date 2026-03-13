using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using IPOApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using IPOApi.STADataAccess;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static IPOApi.Models.DatasetModel;
using static IPOApi.Models.ReconModel;
namespace ReconDataLayer
{
    public class ReconData
    {
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        List<IDbDataParameter>? parameters;
        public DataTable recntypeData(UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_recontype", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_recontype" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(headerval), "pr_get_recontype", headerval.user_code, constring);
                logger(ex.Message);
                return result;
            }
        }


        public DataTable recnlistData(Reconlist objreconlist, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_user_code", objreconlist.in_user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_recon_mst_trecon_list", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_recon_mst_trecon_list" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + JsonConvert.SerializeObject(objreconlist), "pr_recon_mst_trecon_list", headerval.user_code, constring);
                return result;
            }
        }


        public DataSet fetchRecondtl(fetchRecon objfetch, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objfetch.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedurelist("pr_fetch_recondetail", CommandType.StoredProcedure, parameters.ToArray());
                if (ds.Tables.Count >= 8)
                {
                    ds.Tables[0].TableName = "ReconHeader";
                    ds.Tables[1].TableName = "ReconDataSet";
                    ds.Tables[2].TableName = "ReconDataSetmapping";
                    ds.Tables[3].TableName = "Reconfield";
                    ds.Tables[4].TableName = "ReconRule";
                    ds.Tables[5].TableName = "Recontheme";
                    ds.Tables[6].TableName = "Reconpreprocess";
                    ds.Tables[7].TableName = "Rpttemplate";
                }
                return ds;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_fetch_recondetail" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + objfetch, "pr_fetch_recondetail", headerval.user_code, constring);
                return ds;
            }

        }

        public DataTable recondatamapping(datamapping objdatamapping, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_reconfield_gid", objdatamapping.in_reconfield_gid, DbType.Int16, ParameterDirection.InputOutput));
                parameters.Add(dbManager.CreateParameter("in_reconfieldmapping_gid", objdatamapping.in_reconfieldmapping_gid, DbType.Int16));
                parameters.Add(dbManager.CreateParameter("in_recon_code", objdatamapping.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_field_name", objdatamapping.in_recon_field_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_display_order", objdatamapping.in_display_order, DbType.Decimal));
                parameters.Add(dbManager.CreateParameter("in_dataset_code", objdatamapping.in_dataset_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_dataset_field_name", objdatamapping.in_dataset_field_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_active_status", objdatamapping.in_active_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", objdatamapping.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action_by", objdatamapping.in_user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_recon_trn_trecondatamapping", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_recon_trn_trecondatamapping" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param" + JsonConvert.SerializeObject(objdatamapping), "pr_recon_trn_trecondatamapping", headerval.user_code, constring);
                return result;
            }
        }

        public DataTable recondatafielddata(datafieldmodel objdatafieldmodel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_reconfield_gid", objdatafieldmodel.in_reconfield_gid, DbType.Int16, ParameterDirection.InputOutput));
                parameters.Add(dbManager.CreateParameter("in_recon_code", objdatafieldmodel.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_field_name", objdatafieldmodel.in_recon_field_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_field_alias_name", objdatafieldmodel.in_recon_field_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_display_order", objdatafieldmodel.in_display_order, DbType.Decimal));
                parameters.Add(dbManager.CreateParameter("in_field_type", objdatafieldmodel.field_type, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_field_length", objdatafieldmodel.field_length, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_precision_length", objdatafieldmodel.precision_length, DbType.Int64));
                parameters.Add(dbManager.CreateParameter("in_scale_length", objdatafieldmodel.scale_length, DbType.Int64));
                parameters.Add(dbManager.CreateParameter("in_active_status", objdatafieldmodel.in_active_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", objdatafieldmodel.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action_by", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_recon_mst_treconfield", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_recon_mst_treconfield" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objdatafieldmodel), "pr_recon_mst_treconfield", headerval.user_code, constring);
                return result;
            }
        }

        public DataTable recondatamappingdelete(datamapping objdatamapping, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_reconfieldmapping_gid", objdatamapping.in_reconfieldmapping_gid, DbType.Int16));
                parameters.Add(dbManager.CreateParameter("in_action", objdatamapping.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_recon_trn_trecondatamappingdelete", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_recon_trn_trecondatamapping" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objdatamapping), "pr_recon_trn_trecondatamappingdelete", headerval.user_code, constring);
                return result;
            }
        }

        public DataTable Recon(Recon recon, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>();

                parameters.Add(dbManager.CreateParameter("in_recon_gid", recon.in_recon_gid, DbType.Int16, ParameterDirection.InputOutput));
                parameters.Add(dbManager.CreateParameter("in_recon_code", recon.in_recon_code, DbType.String, ParameterDirection.InputOutput));
                parameters.Add(dbManager.CreateParameter("in_recon_name", recon.in_recon_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recontype_code", recon.in_recontype_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_automatch_partial", recon.in_recon_automatch_partial, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_period_from", recon.in_period_from, DbType.Date));
                parameters.Add(dbManager.CreateParameter("in_period_to", recon.in_period_to, DbType.Date));
                parameters.Add(dbManager.CreateParameter("in_closure_date", recon.closure_date, DbType.Date));
                parameters.Add(dbManager.CreateParameter("in_cycle_date", recon.cycle_date, DbType.Date));
                parameters.Add(dbManager.CreateParameter("in_until_active_flag", recon.in_until_active_flag, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_date_flag", recon.in_recon_date_flag, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_date_field", recon.in_recon_date_field, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_value_flag", recon.in_recon_value_flag, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_value_field", recon.in_recon_value_field, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_threshold_code", recon.threshold_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_threshold_plus_value", recon.in_threshold_plus_value, DbType.Double));
                parameters.Add(dbManager.CreateParameter("in_threshold_minus_value", recon.in_threshold_minus_value, DbType.Double));
                parameters.Add(dbManager.CreateParameter("in_processing_method", recon.in_processing_method, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_theme_flag", recon.in_recon_theme_flag, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_active_reason", recon.in_active_reason, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_active_status", recon.in_active_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", recon.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action_by", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_recon_mst_trecon_new", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_recon_mst_trecon_new" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(recon), "pr_recon_mst_trecon_new", headerval.user_code, constring);
                throw ex;
            }
        }

        public DataTable Recondatset(Recondataset objrecondataset, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recondataset_gid", objrecondataset.in_recondataset_gid, DbType.Int16, ParameterDirection.InputOutput));
                parameters.Add(dbManager.CreateParameter("in_recon_code", objrecondataset.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_dataset_code", objrecondataset.in_dataset_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_dataset_type", objrecondataset.in_dataset_type, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_parent_dataset_code", objrecondataset.in_parent_dataset_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_active_status", objrecondataset.in_active_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", objrecondataset.in_action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action_by", objrecondataset.in_user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));

                ds = dbManager.execStoredProcedure("pr_recon_mst_trecondataset", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_recon_mst_trecondataset" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objrecondataset), "pr_recon_mst_trecondataset", headerval.user_code, constring);
                return result;
            }
        }


        public DataTable Recondatamappinglist(getReconDataMappingList objdatamappinglist, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objdatamappinglist.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_field_name", objdatamappinglist.in_recon_field_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_dataset_code", objdatamappinglist.in_dataset_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_recon_datamapping_list", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_recon_datamapping_list" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objdatamappinglist), "pr_get_recon_datamapping_list", headerval.user_code, constring);
                return result;
            }
        }




        public DataTable ReconFieldAgainstReconlist(getFieldAgainstReconList objfieldlist, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objfieldlist.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_field_againt_recon", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_field_againt_recon" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objfieldlist), "pr_get_field_againt_recon", headerval.user_code, constring);
                return result;
            }
        }


        public DataTable reconlistknockoff(UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_reconlist_knockoff", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_reconlist_knockoff" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(headerval), "pr_get_reconlist_knockoff", headerval.user_code, constring);
                return result;
            }
        }

        //recon against recontypecode
        public DataTable reconagainsttypecodeData(Reconagainsttypecode objreconlist, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recontype_code", objreconlist.in_recontype_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_reconagainst_typecode", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_reconagainst_typecode" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objreconlist), "pr_get_reconagainst_typecode", headerval.user_code, constring);
                return result;
            }
        }
        public void logger(string sMessage)
        {
            string logFilePath = "D;//recon_logger/error.log";

            // Ensure the directory exists
            string logDirectory = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            // Append the error information to the log file
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"Timestamp: {DateTime.Now}");

                writer.WriteLine($"Message: {sMessage}");
                writer.WriteLine(new string('-', 40)); // Separator between entries
            }
        }
        public DataSet Datasetfielddata(Datasetfieldlist Objmodel, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_dataset_code", Objmodel.datasetCode, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_Datasetfielddetail", CommandType.StoredProcedure, parameters.ToArray());
                ds.Tables[0].TableName = "DataSet";
                return ds;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_Datasetfielddetail" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(Objmodel), "pr_get_Datasetfielddetail", headerval.user_code, constring);
                return ds;
            }
        }
        //cloneReconData

        public DataTable cloneReconData(cloneReconModel objcloneRecon, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                //parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_name", objcloneRecon.in_recon_name, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_clone_recon_code", objcloneRecon.in_clone_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_datasetmap", objcloneRecon.in_datasetmap, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_recon_code", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_clone_recon", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[2];
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                dt1 = ds.Tables[0];
                dt2 = ds.Tables[1];
                string clonefilepath = dt2.Rows[0]["config_value"].ToString();
                
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    string clone_file_name = dt1.Rows[i]["clone"].ToString();
                    string new_file_name = dt1.Rows[i]["new"].ToString();
                    string file_name = dt1.Rows[i]["file_name"].ToString();
                    CopyAndRenameFile(clone_file_name, new_file_name, clonefilepath, file_name);
                }
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_clone_recon" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objcloneRecon), "pr_clone_recon", headerval.user_code, constring);
                return result;
            }
        }
        public void CopyAndRenameFile(string sourceFileName, string destinationFileName, string clonefilepath,string file_name)
        {
            try
            {
                //string[] lastIndex = sourceFileName.Split(".");
                //string fileExtension = lastIndex[1];

                string fileExtension = file_name.Substring(file_name.LastIndexOf('.'));
                destinationFileName = clonefilepath + destinationFileName + fileExtension;
                sourceFileName = clonefilepath + sourceFileName + fileExtension;

                // Check if the source file exists
                if (System.IO.File.Exists(sourceFileName))
                {
                    // Copy the file to the destination and overwrite if it already exists
                    System.IO.File.Copy(sourceFileName, destinationFileName, true);
                }
                else
                {
                    Console.WriteLine("Source file does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        //cloneReconDatasetData
        public DataTable cloneReconDatasetData(cloneReconDatasetModel objcloneReconDataset, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                //parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_recon_code", objcloneReconDataset.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_dataset_code", objcloneReconDataset.in_dataset_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_dataset_type", objcloneReconDataset.in_dataset_type, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_parent_dataset_code", objcloneReconDataset.in_parent_dataset_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_clone_dataset_code", objcloneReconDataset.in_clone_dataset_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_clone_recon_code", objcloneReconDataset.in_clone_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_clone_recondataset", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_clone_recondataset" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objcloneReconDataset), "pr_clone_recondataset", headerval.user_code, constring);
                return result;
            }
        }

        public DataSet fetchCloneRecondtl(fetchRecon objfetch, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objfetch.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedurelist("pr_fetch_clonerecondetail", CommandType.StoredProcedure, parameters.ToArray());
                if (ds.Tables.Count >= 5)
                {
                    ds.Tables[0].TableName = "ReconHeader";
                    ds.Tables[1].TableName = "ReconDataSet";
                    ds.Tables[2].TableName = "ReconDataSetmapping";
                    ds.Tables[3].TableName = "Reconfield";
                    ds.Tables[4].TableName = "ReconRule";
                }
                return ds;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_fetch_recondetail" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objfetch), "pr_fetch_clonerecondetail", headerval.user_code, constring);
                return ds;
            }

        }
        public DataTable ReconDatasetlistData(UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_fetch_ReconDatasetlist", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_recon_mst_trecon_list" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(headerval), "pr_fetch_ReconDatasetlist", headerval.user_code, constring);
                return result;
            }
        }

        //getReconforOpeningBalanceData

        public DataTable getReconforOpeningBalanceData(UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_recon_openingbalance", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_recon_openingbalance" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(headerval), "pr_get_recon_openingbalance", headerval.user_code, constring);
                return result;
            }
        }
        //getdatasetagainstReconData

        public DataTable getdatasetagainstReconData(openingbalanceDatasetModel objReconDataset, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objReconDataset.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_dataset_againstRecon", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_dataset_againstRecon" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objReconDataset), "pr_get_dataset_againstRecon", headerval.user_code, constring);
                return result;
            }
        }
        public DataTable ReconDatasetmaplist_db(fetchRecon objfetch, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objfetch.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_fetch_Datasetmaplist", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_fetch_Datasetmaplist" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objfetch), "pr_fetch_Datasetmaplist", headerval.user_code, constring);
                return result;
            }
        }

        //ArcheiveReconData
        public DataTable ArcheiveReconData(ArcheiveReconobj objArcheiveRecon, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objArcheiveRecon.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", objArcheiveRecon.in_user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_set_reconarchival", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_set_reconarchival" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objArcheiveRecon), "pr_set_reconarchival", headerval.user_code, constring);
                return result;
            }
        }

        public DataTable ArcheiveReconlistData(ArcheiveReconobj objArcheiveRecon, UserManagementModel.headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_recon_code", objArcheiveRecon.in_recon_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", objArcheiveRecon.in_user_code, DbType.String));               
                ds = dbManager.execStoredProcedure("pr_get_reconarchivallist", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_set_reconarchival" + "Error Message:" + ex.Message);
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objArcheiveRecon), "pr_set_reconarchival", headerval.user_code, constring);
                return result;
            }
        }
    }
}

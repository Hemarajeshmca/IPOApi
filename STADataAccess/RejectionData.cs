using IPOApi.Models;
using System.Data;

namespace IPOApi.STADataAccess
{
    public class RejectionData
    {
        DataSet ds = new DataSet();
        List<IDbDataParameter>? parameters;
        CommonHeader objlog = new CommonHeader();
        string constring1 = "";
        DataTable result = new DataTable();


        public DataTable GetRejData(string offer_code, bool runRule, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_reference_no", offer_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_runRule", runRule, DbType.Boolean));
                ds = dbManager.execStoredProcedure("pr_ipo_get_rejection_count", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_ipo_get_rejection" + "Error Message:" + ex.Message);
                return result;
            }
        }

        public DataTable GetRejdetailData(string offer_code, string rule_code, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_reference_no", offer_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_rule_code", rule_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_get_reject_recon_detail", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_reject_recon_detail" + "Error Message:" + ex.Message);
                return result;
            }
        }

        // runRejectionData

        public DataTable runRejectionData(string offer_code, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_ipo_code", offer_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_run_boa", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_run_boa" + "Error Message:" + ex.Message);
                return result;
            }
        }

        public DataSet GetAddRejData(string ipo_code, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_ipo_code", ipo_code, DbType.String));
                ds = dbManager.execStoredProcedurelist("pr_ipo_get_additonrejection_details", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_ipo_get_additonrejection_details Error Message: " + ex.Message);
            }
            return ds;
        }

        public DataSet saveaddrejdetail(RejectionModel insObj, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>(); // if no params, leave empty
                parameters.Add(dbManager.CreateParameter("in_ipo_code", insObj.ipo_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_applno", insObj.applno, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_orderno", insObj.orderno, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_panno", insObj.panno, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_quantity", insObj.qty, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_price", insObj.shares, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_amount", insObj.amt, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_rule_code", insObj.rule_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_add", insObj.addremarks, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_reject", insObj.rejremarks, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.Int32, ParameterDirection.Output));
                ds = dbManager.execStoredProcedurelist("pr_ipo_set_additionrejection_single", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_tclientdetails Error Message: " + ex.Message);
            }

            return ds;
        }

        public DataSet Getrulecode(string constring1, string ipo_code)
        {
            DataSet ds = new DataSet();
            try
            {
                DBManager dbManager = new DBManager(constring1);
                parameters = new List<IDbDataParameter>(); // if no params, leave empty
                parameters.Add(dbManager.CreateParameter("in_ipo_code", ipo_code, DbType.String));                                         // parameters.Add(dbManager.CreateParameter("in_rule_code", rulecode, DbType.String));
                ds = dbManager.execStoredProcedurelist("pr_ipo_get_rulemaster", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_ipo_get_rulemaster Error Message: " + ex.Message);
            }
            return ds;
        }


    }
}

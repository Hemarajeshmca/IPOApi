using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPOApi.Models;
using Newtonsoft.Json;
namespace IPOApi.STADataAccess
{
    public class RuleMastersData
    { 
        List<IDbDataParameter> parameters;

        public DataSet Getrulecode(string constring1, string ipo_code)
        {
            DataSet ds = new DataSet();
            try
            {
                DBManager dbManager = new DBManager(constring1);
                parameters = new List<IDbDataParameter>(); // if no params, leave empty
                parameters.Add(dbManager.CreateParameter("in_ipo_code", ipo_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", "F", DbType.String));
                ds = dbManager.execStoredProcedurelist("pr_ipo_get_rulemaster_ipo", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_ipo_get_rulemaster Error Message: " + ex.Message);
            }
            return ds;
        }

        public DataSet SaveAppliedRules(RuleSaveModel insObj, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>(); // if no params, leave empty in_remarks
                parameters.Add(dbManager.CreateParameter("in_ipo_code", insObj.ipo_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_rule_code", insObj.rule_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_remarks", insObj.remarks, DbType.String));                
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.Int32, ParameterDirection.Output));
                ds = dbManager.execStoredProcedurelist("pr_ipo_set_rulemapping", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_ipo_set_rulemapping Error Message: " + ex.Message);
            }

            return ds;
        }
    }
}

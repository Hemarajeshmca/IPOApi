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
    public class BankmastersData
    {
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        List<IDbDataParameter> parameters;

        public DataTable getallbankdata(Qcdgridread objgridread, headerValue headerval, string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess(objgridread.in_user_code);
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_master_code", objgridread.in_master_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_role_code", headerval.role_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_lang_code", headerval.lang_code, DbType.String));
                ds = dbManager.execStoredProcedure("pr_ipo_get_allbankmaster", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_allqcdmaster" + "Error Message:" + ex.Message);
                //objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objgridread), "pr_get_allqcdmaster", headerval.user_code, constring);
                return result;
            }
        }
    }
}

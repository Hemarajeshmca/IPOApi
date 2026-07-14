using System.Data; 
namespace IPOApi.STADataAccess
{
    public class PlusMinusData
    {
        List<IDbDataParameter> parameters;
        public DataSet FetchPlusMinus(string constring1, string ipo_code)
        {
            DataSet ds = new DataSet();
            try
            {
                DBManager dbManager = new DBManager(constring1);
                parameters = new List<IDbDataParameter>(); // if no params, leave empty
                parameters.Add(dbManager.CreateParameter("in_ipo_code", ipo_code, DbType.String)); 
                ds = dbManager.execStoredProcedurelist("pr_ipo_get_additonrejection_list", CommandType.StoredProcedure, parameters.ToArray());
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

using IPOApi.Models;
using MySql.Data.MySqlClient;
using System.Data;
using static IPOApi.Models.IssueSetupModel;
using static IPOApi.Models.UtilityModel;
using static System.Net.WebRequestMethods;

namespace IPOApi.STADataAccess
{
    public class IssueSetupData
    { 
        DataTable result = new DataTable();  
        DataSet ds = new DataSet();
        List<IDbDataParameter>? parameters;
        CommonHeader objlog = new CommonHeader();
        string constring1 = "";
        public DataSet getofferType(IssueSetupModel inscObj, string constring)
        {
            try
            { 
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("p_master_code", inscObj.mastercode, DbType.String));
                parameters.Add(dbManager.CreateParameter("p_depend_value", inscObj.dependvalue, DbType.String));
                ds = dbManager.execStoredProcedurelist("pr_get_masterlist", CommandType.StoredProcedure, parameters.ToArray());
            }
            catch (Exception ex)
            {
                // Log error if any
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:sp_get_masterlist" + " Error Message:" + ex.Message);
            }

            return ds; // Return the DataSet with results
        }

        public DataSet Get_Offerlist(string client_code, headerValue headerval, string constring)
        {
            DBManager dbManager = new DBManager(constring);
            parameters = new List<IDbDataParameter>();

            parameters.Add(dbManager.CreateParameter("in_client_code", client_code, DbType.String));
            parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));

            parameters.Add(dbManager.CreateParameter("out_msg", "", DbType.String, ParameterDirection.Output));
            parameters.Add(dbManager.CreateParameter("out_result", 0, DbType.Int32, ParameterDirection.Output));

            DataSet ds = dbManager.execStoredProcedure(
                "pr_ipo_get_offerlist",
                CommandType.StoredProcedure,
                parameters.ToArray()
            );

            return ds;
        }

        public DataTable setoffer_header(OfferHeaderModel offerheader, headerValue headerval, string constring)
        {
            DataTable result = new DataTable();

            try
            {
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>(); 

                parameters.Add(dbManager.CreateParameter("in_action", offerheader.action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_offer_header_gid", offerheader.offer_header_gid, DbType.Int32));
                parameters.Add(dbManager.CreateParameter("in_offer_code", offerheader.offer_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_offer_type", offerheader.offer_type, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_offer_listing", offerheader.offer_listing_no, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_offer_isin", offerheader.offer_isin, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_offer_status", offerheader.offer_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_offer_remarks", offerheader.offer_remarks, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_client_code", offerheader.client_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_active_status", offerheader.active_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", 0, DbType.Int32, ParameterDirection.Output));
                DataSet ds = dbManager.execStoredProcedure(
                    "pr_offer_header",
                    CommandType.StoredProcedure,
                    parameters.ToArray()
                );

                if (ds != null && ds.Tables.Count > 0)
                {
                    result = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP: pr_offer_header | Error: " + ex.Message);
            }

            return result;
        }

        public DataTable Set_OfferDetail(OfferDetailModel offerdetail, headerValue headerval, string constring)
        {
            DataTable result = new DataTable();

            try
            {
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>();
                parameters.Add(dbManager.CreateParameter("in_action", offerdetail.action, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_offer_detail_gid", offerdetail.offer_detail_gid, DbType.Int32));
                parameters.Add(dbManager.CreateParameter("in_offer_precapital", offerdetail.offer_precapital, DbType.Decimal));
                parameters.Add(dbManager.CreateParameter("in_offer_issuesize", offerdetail.offer_issuesize, DbType.Int32));
                parameters.Add(dbManager.CreateParameter("in_offer_postcapital", offerdetail.offer_postcapital, DbType.Decimal));
                parameters.Add(dbManager.CreateParameter("in_offer_lotsize", offerdetail.offer_lotsize, DbType.Int32));
                parameters.Add(dbManager.CreateParameter("in_offer_facevalue", offerdetail.offer_facevalue, DbType.Decimal));
                parameters.Add(dbManager.CreateParameter("in_offer_premiun", offerdetail.offer_premiun, DbType.Decimal));
                parameters.Add(dbManager.CreateParameter("in_offer_pricetype", offerdetail.offer_pricetype, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_offer_fixedprice", offerdetail.offer_fixedprice, DbType.Decimal));
                parameters.Add(dbManager.CreateParameter("in_offer_maximumprice", offerdetail.offer_maximumprice, DbType.Decimal));
                parameters.Add(dbManager.CreateParameter("in_offer_minimumprice", offerdetail.offer_minimumprice, DbType.Decimal));
                parameters.Add(dbManager.CreateParameter("in_offer_cutoffprice", offerdetail.offer_cutoffprice, DbType.Decimal));
                parameters.Add(dbManager.CreateParameter("in_offer_code", offerdetail.offer_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_client_code", offerdetail.client_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_user_code", headerval.user_code, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_action", offerdetail.action, DbType.String)); 
                parameters.Add(dbManager.CreateParameter("out_msg", "", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", 0, DbType.Int32, ParameterDirection.Output));
                DataSet ds = dbManager.execStoredProcedure(
                    "pr_offer_detail",
                    CommandType.StoredProcedure,
                    parameters.ToArray()
                );

                if (ds != null && ds.Tables.Count > 0)
                {
                    result = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP: pr_offer_detail | Error: " + ex.Message);
            }

            return result;
        }

    }
}

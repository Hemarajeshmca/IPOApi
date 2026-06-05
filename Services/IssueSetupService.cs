using IPOApi.Models;
using IPOApi.STADataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IPOApi.Models.IssueSetupModel;
//using static IPOApi.Models.UserManagementModel;
using static IPOApi.Models.UtilityModel;
namespace IPOApi.Services
{
    public class IssueSetupService
    {
        public static DataSet getofferType(IssueSetupModel inscObj, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                IssueSetupData objData = new IssueSetupData();
                ds = objData.getofferType(inscObj, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
        public static DataSet Get_Offerlist(string in_user_code, string in_role_code, headerValue headerval, string constring)
        {
            DataSet ds = new DataSet();

            try
            {
                IssueSetupData objData = new IssueSetupData();
                ds = objData.Get_Offerlist(in_user_code, in_role_code, headerval, constring);
            }
            catch (Exception)
            {
            }

            return ds;
        }

        public static DataSet Get_OfferFetch(string client_code, string offer_code, headerValue headerval, string constring)
        {
            DataSet ds = new DataSet();

            try
            {
                IssueSetupData objData = new IssueSetupData();
                ds = objData.Get_OfferFetch(client_code, offer_code, headerval, constring);
            }
            catch (Exception)
            {
            }

            return ds;
        }
        public static DataTable setoffer_header(OfferHeaderModel offerheader, headerValue headerval, string constring)
        {
            DataTable dt = new DataTable();
            try
            {
                IssueSetupData objData = new IssueSetupData();
                dt = objData.setoffer_header(offerheader, headerval, constring);
            }
            catch (Exception e)
            { }
            return dt;
        }

        public static DataTable Set_OfferDetail(OfferDetailModel offerdetail, headerValue headerval, string constring)
        {
            DataTable dt = new DataTable();
            try
            {
                IssueSetupData objData = new IssueSetupData();
                dt = objData.Set_OfferDetail(offerdetail, headerval, constring);
            }
            catch (Exception e)
            { }
            return dt;
        }

        public static DataTable Set_OfferBankers(OfferBankerModel offerdetail, headerValue headerval, string constring)
        {
            DataTable dt = new DataTable();
            try
            {
                IssueSetupData objData = new IssueSetupData();
                dt = objData.Set_OfferBankers(offerdetail, headerval, constring);
            }
            catch (Exception e)
            { }
            return dt;
        }
        public static DataTable SetOfferStack(OfferStackModel offerdetail, headerValue headerval, string constring)
        {
            DataTable dt = new DataTable();
            try
            {
                IssueSetupData objData = new IssueSetupData();
                dt = objData.SetOfferStack(offerdetail, headerval, constring);
            }
            catch (Exception e)
            { }
            return dt;
        }

        public static DataSet GetStacklist(string action, string client_code, string offer_code, string stack_code,headerValue headerval, string constring)
        {
            DataSet ds = new DataSet();

            try
            {
                IssueSetupData objData = new IssueSetupData();
                ds = objData.GetStackFetch(action, client_code, offer_code, stack_code, headerval, constring);
            }
            catch (Exception)
            {
            }

            return ds;
        }

        public static DataTable SetOffermiles(MilestoneModel offerdetail, headerValue headerval, string constring)
        {
            DataTable dt = new DataTable();
            try
            {
                IssueSetupData objData = new IssueSetupData();
                dt = objData.SetOffermiles(offerdetail, headerval, constring);
            }
            catch (Exception e)
            { }
            return dt;
        }

        public static DataSet GetOffermiles( string client_code, string offer_code, headerValue headerval, string constring)
        {
            DataSet ds = new DataSet();

            try
            {
                IssueSetupData objData = new IssueSetupData();
                ds = objData.GetOffermiles(client_code, offer_code, headerval, constring);
            }
            catch (Exception)
            {
            }

            return ds;
        }

        public static DataTable SetOfferCategory(CategoryModel offerdetail, headerValue headerval, string constring)
        {
            DataTable dt = new DataTable();
            try
            {
                IssueSetupData objData = new IssueSetupData();
                dt = objData.SetOfferCategory(offerdetail, headerval, constring);
            }
            catch (Exception e)
            { }
            return dt;
        }

        public static DataSet GetOfferCategory(string client_code, string offer_code, headerValue headerval, string constring)
        {
            DataSet ds = new DataSet();

            try
            {
                IssueSetupData objData = new IssueSetupData();
                ds = objData.GetOfferCategory(client_code, offer_code, headerval, constring);
            }
            catch (Exception)
            {
            }

            return ds;
        }

        public static DataSet GetAuditTrailService(string offer_code, string constring)
        {
            DataSet ds = new DataSet();

            try
            {
                IssueSetupData objData = new IssueSetupData();
                ds = objData.GetAuditTrailData(offer_code, constring);
            }
            catch (Exception)
            {
            }

            return ds;
        }

    }
}

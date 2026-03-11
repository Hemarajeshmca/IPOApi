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
        public static DataSet Get_Offerlist(string client_code, headerValue headerval, string constring)
        {
            DataSet ds = new DataSet();

            try
            {
                IssueSetupData objData = new IssueSetupData();
                ds = objData.Get_Offerlist(client_code, headerval, constring);
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


    }
}

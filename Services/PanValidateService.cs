using IPOApi.Models;
using IPOApi.STADataAccess;
using System.Data;

namespace IPOApi.Services
{
    public class PanValidateService
    {
        public static DataTable PanValidService(string offer_code, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                PanValidateData objDS = new PanValidateData();
                ds = objDS.panvaliddata(offer_code, constring);
            }
            catch (Exception e)
            { }
            return ds;        }

      

    }
}

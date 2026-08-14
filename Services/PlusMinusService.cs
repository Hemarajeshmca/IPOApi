 
using IPOApi.STADataAccess; 
using System.Data; 
namespace IPOApi.Services
{
    public class PlusMinusService
    {
        public static DataSet FetchPlusMinus(string constring, string ipo_code)
        {
            DataSet ds = new DataSet();
            try
            {
                PlusMinusData objData = new PlusMinusData();
                ds = objData.FetchPlusMinus(constring, ipo_code);
            }
            catch (Exception)
            {
            }
            return ds;
        }
    }
}

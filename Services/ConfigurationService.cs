using IPOApi.STADataAccess;
using System.Data;

namespace IPOApi.Services
{
    public class ConfigurationService
    {
        public static DataTable fetchconfigservice(string constring)
        {
            DataTable ds = new DataTable();

            try
            {
                ConfigurationData objDS = new ConfigurationData();

                ds = objDS.fetchconfigData(constring);
            }
            catch (Exception e)
            {
            }

            return ds;
        }

        public static DataTable UpdateConfig(string json,int userId,string constring)
        {
            ConfigurationData objData = new ConfigurationData();
            return objData.UpdateConfig(
                json,
                userId,
                constring);
        }
    }
}
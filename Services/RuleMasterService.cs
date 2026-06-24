
using IPOApi.Models;
using IPOApi.STADataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace IPOApi.Services
{
    public class RuleMasterService
    {
        public static DataSet Getrulecode(string constring, string ipo_code)
        {
            DataSet ds = new DataSet();
            try
            {
                RuleMastersData objData = new RuleMastersData();
                ds = objData.Getrulecode(constring, ipo_code);
            }
            catch (Exception)
            {
            }
            return ds;
        }
        public static DataSet SaveAppliedRules(RuleSaveModel insOb, string constring)
        {
            DataSet ds = new DataSet();

            try
            {
                RuleMastersData objData = new RuleMastersData();
                ds = objData.SaveAppliedRules(insOb, constring);
            }
            catch (Exception)
            {
            }

            return ds;
        }
    }
}

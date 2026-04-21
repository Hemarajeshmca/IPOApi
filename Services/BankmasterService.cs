
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPOApi.Models;
using IPOApi.STADataAccess;

namespace IPOApi.Services
{
    public class BankmasterService
    {
        public static DataTable getallbankservice(Qcdgridread objgridread, headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                BankmastersData objqcd = new BankmastersData();
                ds = objqcd.getallbankdata(objgridread, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

    }
}

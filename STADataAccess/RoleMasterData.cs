using DocumentFormat.OpenXml.Drawing.Diagrams;
using IPOApi.Models;
using IPOApi.STADataAccess;
using IPOApi.STADataAccess.Interface;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RoleMasterData
    {
    private string constring;
    DataSet ds = new DataSet();
        DataTable result = new DataTable();
        List<IDbDataParameter> parameters;
    public RoleMasterData(IConfiguration configuration)
    {
        constring = configuration["Appsettings:ConnectionStrings"];
    }
    public DataSet getroleList(string constring)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                parameters = new List<IDbDataParameter>(); // if no params, leave empty 
                ds = dbManager.execStoredProcedurelist("pr_get_allroles", CommandType.StoredProcedure, parameters.ToArray());
               
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.logger("SP:pr_get_allroles" + "Error Message:" + ex.Message);
                //objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(objgridread), "pr_get_allqcdmaster", headerval.user_code, constring);
                
            }
            return ds;
        }


        public DataSet SaveUserRoles(SaveUserRolesRequest request, string constring)
        {
            DBManager dbManager = new DBManager(constring);

            var parameters = new List<IDbDataParameter>();

            // Convert roles to JSON string
            var jsonRoles = System.Text.Json.JsonSerializer.Serialize(request.roles);

            parameters.Add(dbManager.CreateParameter("in_user_code", request.user_code, DbType.String));
            parameters.Add(dbManager.CreateParameter("in_roles_json", jsonRoles, DbType.String));

            DataSet ds = dbManager.execStoredProcedurelist(
                "pr_save_userrole_mapping",
                CommandType.StoredProcedure,
                parameters.ToArray()
            );

            return ds;
        }

    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace IPOApi.Models
{
    public class UserManagementModel
    {
        public class Login_model
        {
            public string user_id { get; set; }
            public string user_name { get; set; }
            public string password { get; set; }
            public string datasource { get; set; }
            public string msg { get; set; }
            public string ip { get; set; }
        }

        public class change_password
        {
            public string user_id { get; set; }
            public string old_password { get; set; }
            public string new_password { get; set; }
            public string out_msg { get; set; }
            public int out_result { get; set; }

        }

        public class headerValue
        {
            public string user_code { get; set; } = "";
            public string role_code { get; set; } = "";
            public string lang_code { get; set; } = "";
            public string ip_address { get; set; } = "";

            public string in_context_code { get; set; } = "";
        }


        public class dashboardmodel
        {
            public string in_recon_code { get; set; }
            public string in_period_from { get; set; }
            public string in_period_to { get; set; }
            public string in_conversion_type { get; set; }
        }
        public class User_model
        {
            public string user_code { get; set; }
            public string user_contact_no { get; set; }
            public string user_emailid { get; set; }
            public int user_gid { get; set; }
            public string user_name { get; set; }
            public string winauth { get; set; }
            public string user_password { get; set; }
            public string action { get; set; }
            public string action_by { get; set; }
            public string in_active_reason { get; set; }
            public string role_code { get; set; }
            public String? out_msg { get; set; }
            public Int16? out_result { get; set; }
        }
        public class treeviewllist
        {
            public List<treeviewllist> items = new List<treeviewllist>();
            public string depend_code { get; set; }
            public string master_code { get; set; }
            public string master_name { get; set; }
            public string parent_code { get; set; }
            public string id { get; set; }
            public int gid { get; set; }
            public string unitDependCode { get; set; }
        }
        public class usermappingmodel
        {
            public string user_code { get; set; }
            public int user_gid { get; set; }
            public string level_mapping { get; set; }
            public String? out_msg { get; set; }
            public Int16? out_result { get; set; }
        }
        public class getcheckedmodel
        {
            public string user_code { get; set; }
            public int user_gid { get; set; }
        }
        public class setcontextmodel
        {
            public string user_code { get; set; }
            public string level_mapping { get; set; }
            public String? out_msg { get; set; }
            public Int16? out_result { get; set; }
        }
        public class getcontexttmodel
        {
            public string user_code { get; set; }
        }
        public class getmenumodel
        {
            public string user_code { get; set; }
        }
        public class getmenumodel1
        {
            public string user_code { get; set; }
            public string status { get; set; }
        }
    }
}

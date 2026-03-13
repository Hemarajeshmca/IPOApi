using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPOApi.Models
{
    public class CommonModel
    {
        public class errorlogModel
        {
            public string in_ip_addr { get; set; }
            public string in_source_name { get; set; }
            public string in_proc_name { get; set; }
            public string in_errorlog_text { get; set; }
            public string user_code { get; set; }

        }

        public class configvalueModel
        {
            public string in_config_name { get; set; }
            public string in_user_code { get; set; }

        }
        public class roleconfig
        {
            public string in_screen_code { get; set; }
            public string add { get; set; }
            public string edit { get; set; }
            public string view { get; set; }
            public string delete { get; set; }
            public string process { get; set; }
            public string download { get; set; }
            public string deny { get; set; }
        }
        public class reconmindate
        {
            public string in_recon_code { get; set; }
        }
        public class reportvalidatemodel
        {
            public string in_recon_code { get; set; }
            public string in_template_code { get; set; }
            public string exceldownload { get; set; }
            public string csvdownload { get; set; }
            public string preview { get; set; }
            public string deny { get; set; }
            public string in_user_code { get; set; }
        }
        public class ArcheivedatasetlistModel
        {
            public string in_recon_code { get; set; }
            public string? in_user_code { get; set; }
        }
        public class archivaldatasetsaveModel
        {
            public int? in_archivaldataset_gid { get; set; }
            public int? in_archivaldatasetfilter_gid { get; set; }
            public string? in_dataset_code { get; set; }
            public string? in_recon_code { get; set; }
            public string? in_dataset_type { get; set; }
            public string? in_archival_flag { get; set; }
            public Decimal? in_filter_seqno { get; set; }
            public string? in_filter_field { get; set; }
            public string? in_filter_criteria { get; set; }
            public string? in_filter_value_flag { get; set; }
            public string? in_filter_value { get; set; }
            public string? in_open_parentheses_flag { get; set; }
            public string? in_close_parentheses_flag { get; set; }
            public string? in_join_condition { get; set; }
            public string? in_active_status { get; set; }
            public string? in_action { get; set; }
            public string? in_user_code { get; set; }
            public string? out_msg { get; set; }
            public string? out_result { get; set; }
        }
        public class ArcheivedatasetfetchModel
        {
            public string in_recon_code { get; set; }
            public string? in_dataset_code { get; set; }
        }
    }
}

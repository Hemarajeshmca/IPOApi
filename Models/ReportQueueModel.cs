using System;
using System.Collections.Generic;

namespace IPOApi.Models
{
    public class ReportQueueModel
    {
        public class reportqueue
        {
            public string? in_archival_code { get; set; }
            public String? in_reporttemplate_code { get; set; }
            public string? in_report_code { get; set; }
            public string? in_recon_code { get; set; }
            public String? in_report_param { get; set; }
            public String? in_report_condition { get; set; }
            public String? in_ip_addr { get; set; }
            public Boolean? in_outputfile_flag { get; set; }
            public String? in_outputfile_type { get; set; }
            public string? in_user_code { get; set; }
            public string? file_name { get; set; }
            public string? in_report_name { get; set; }
            public string? in_reporttemplateresultset_code { get; set; }

        }

        public class DataModel
        {
            public string Dataset1 { get; set; }
            public string Dataset2 { get; set; }
        }
    }
}

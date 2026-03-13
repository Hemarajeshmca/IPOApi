using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPOApi.Models
{
	public class ResultSetModel
	{
        public string? reporttemplate_code { get; set; } // hari changes 08-09-25
        public Int64? reportresultset_gid { get; set; }
		public string? report_code { get; set; }
		public string? resultset_name { get; set; }
		public string? resultset_order { get; set; }
		public string? sheet_name { get; set; }
		public string? resultset_exec_type { get; set; }
		public string? src_report_code { get; set; }
		public string? sp_name { get; set; }
		public string? query {  get; set; }
		public string? active_status { get; set; }
		public DateTime? insert_date  { get; set; }
		public DateTime? update_date { get; set; }
		public string? insert_by { get; set; }
		public string? update_by { get; set; }
		public string? delete_flag { get; set; }
		public string? exec_type_data { get; set; }
		public string? action {  get; set; }
        public class report
        {
            public Int64? report_gid { get; set; }
            public string? report_code { get; set; }
            public string? report_desc { get; set; }
            public string? report_exec_type { get; set; }
            public string? user_code { get; set; }
            public string? action { get; set; }
        }
    }

}

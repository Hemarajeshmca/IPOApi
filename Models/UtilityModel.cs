using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPOApi.Models
{
	public class UtilityModel
	{
		public class JobStatusList
		{
			public String? in_start_date { get; set; }
			public String? in_end_date { get; set; }
			public String? in_jobtype_code { get; set; }
			public String? in_jobstatus { get; set; }
			public string? in_user_code { get; set; }

		}

		public class JobCompleted
		{
			public String? in_start_date { get; set; }
			public String? in_end_date { get; set; }
			public String? in_jobtype_code { get; set; }
			public string? in_user_code { get; set; }

		}
        public class KoQueued
        {
            public String? in_koqueue_remark { get; set; }
            public int in_koqueue_gid { get; set; }
            public string? in_user_code { get; set; }

        }
    }
}

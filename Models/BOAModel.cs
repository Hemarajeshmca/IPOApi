namespace IPOApi.Models
{
    public class BOAModel
    {
    }

    public class insertJobModel
    {
        public string? recon_code { get; set; }
        public string? jobtype_code { get; set; }
        public int job_ref_gid { get; set; }
        public string? job_name { get; set; }
        public string? job_input_param { get; set; }
        public string? job_initiated_by { get; set; }
        public string? ip_addr { get; set; }
        public string? job_status { get; set; }
        public string? job_remark { get; set; }

    }

    public class updateJobModel
    {
        public string? in_job_gid { get; set; }
        public string? in_job_status { get; set; }
        public string? in_job_remark { get; set; }
    }
}

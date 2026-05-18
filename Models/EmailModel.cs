namespace IPOApi.Models
{
    public class EmailModel
    {
        public class IpoEmailRequest
        {
            public int InwardNo { get; set; }
            public string Email { get; set; }
            public string InvestorName { get; set; }
            public string ApplicationNo { get; set; }
            public string AllocationStatus { get; set; }
        }

        public class IpoEmailResult
        {
            public bool IsSuccess { get; set; }
            public string ErrorMessage { get; set; }
        }

        public class IpoEmailModel
        {
            public int email_log_gid { get; set; }
            public string reference_no { get; set; }
            public string appl_no { get; set; }
            public string email_id { get; set; }
            public string investor_name { get; set; }
            public string allotment_status_flag { get; set; }
            public decimal total_amount { get; set; }
            public int quantity { get; set; }
            public int alloted_quantity { get; set; }
        }
    }
}

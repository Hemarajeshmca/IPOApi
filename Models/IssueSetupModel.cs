namespace IPOApi.Models
{
    public class IssueSetupModel
    {
        public int mastergid { get; set; }
        public string mastercode { get; set; }
        public string mastername { get; set; }

        public string dependvalue { get; set; }
    }

    public class OfferHeaderModel
    {
        public string action { get; set; }
        public int offer_header_gid { get; set; }
        public string offer_code { get; set; }

        public string offer_type { get; set; }

        public string offer_listing_no { get; set; }

        public string offer_isin { get; set; }

        public string offer_status { get; set; }

        public string offer_remarks { get; set; }

        public string client_code { get; set; }

        public char active_status { get; set; }

        public DateTime created_date { get; set; }

        public string created_by { get; set; }

        public DateTime updated_date { get; set; }

        public string updated_by { get; set; }

        public char delete_flag { get; set; }
    }

    public class OfferDetailModel
    {
        public int offer_detail_gid { get; set; }

        public decimal offer_precapital { get; set; }

        public int offer_issuesize { get; set; }

        public decimal offer_postcapital { get; set; }

        public int offer_lotsize { get; set; }

        public decimal offer_facevalue { get; set; }

        public decimal offer_premiun { get; set; }

        public string offer_pricetype { get; set; }

        public decimal offer_fixedprice { get; set; }

        public decimal offer_maximumprice { get; set; }

        public decimal offer_minimumprice { get; set; }

        public decimal offer_cutoffprice { get; set; }

        public string offer_code { get; set; }

        public string client_code { get; set; }

        public string user_code { get; set; }

        public string action { get; set; }
    }
}

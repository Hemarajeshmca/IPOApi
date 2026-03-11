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

    public class OfferBankerModel
    {
        public string action { get; set; }

        public int banker_gid { get; set; }

        public string banker_type { get; set; }

        public string banker_name { get; set; }

        public string banker_address { get; set; }

        public int banker_city { get; set; }

        public int banker_state { get; set; }

        public string banker_pincode { get; set; }

        public string banker_accountno { get; set; }

        public string banker_ifsc { get; set; }

        public string offer_code { get; set; }

        public string client_code { get; set; }

        public string user_code { get; set; }
    }
}

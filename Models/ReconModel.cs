using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPOApi.Models
{
    public class ReconModel
    {
        public class Recontype
        {

        }
        public class Datasetfieldlist
        {
            public string? datasetCode { get; set; }
        }
        public class Reconlist
        {
            public string? in_user_code { get; set; }

        }

        public class fetchRecon
        {
            public String? in_recon_code { get; set; }

        }

        public class datamapping
        {
            public Int16? in_reconfield_gid { get; set; }
            public Int16? in_reconfieldmapping_gid { get; set; }
            public string? in_recon_code { get; set; }
            public string? in_recon_field_name { get; set; }
            public Decimal? in_display_order { get; set; }
            public string? in_dataset_code { get; set; }
            public string? in_dataset_field_name { get; set; }
            public string? in_active_status { get; set; }
            public string? in_action { get; set; }
            public string? in_user_code { get; set; }

        }
        public class datamappingdel
        {
            public Int16? in_reconfieldmapping_gid { get; set; }
            public string? in_action { get; set; }
        }
        public class datafieldmodel
        {
            public Int16? in_reconfield_gid { get; set; }
            public string? in_recon_code { get; set; }
            public string? in_recon_field_name { get; set; }
            public Decimal? in_display_order { get; set; }
            public string? field_length { get; set; }
            public int? precision_length { get; set; }
            public int? scale_length { get; set; }
            public string? field_type { get; set; }
            public string? in_active_status { get; set; }
            public string? in_action { get; set; }
            public string? in_user_code { get; set; }
            public String? out_msg { get; set; }
            public Int16? out_result { get; set; }
        }
        public class Recon
        {
            public Int16? in_recon_gid { get; set; }
            public String in_recon_code { get; set; }
            public String in_recon_name { get; set; }
            public String in_recontype_code { get; set; }
            public String in_recon_automatch_partial { get; set; }
            public DateOnly in_period_from { get; set; }
            public DateOnly in_period_to { get; set; }
            public DateOnly closure_date { get; set; }
            public DateOnly cycle_date { get; set; }
            public String in_until_active_flag { get; set; }
            public String in_active_status { get; set; }
            public String in_recon_date_flag { get; set; }
            public String in_recon_date_field { get; set; }
            public String in_recon_value_flag { get; set; }
            public String in_recon_value_field { get; set; }
            public Double in_threshold_plus_value { get; set; }
            public Double in_threshold_minus_value { get; set; }
            public String? in_recon_theme_flag { get; set; }
            public String in_active_reason { get; set; }
            public String in_processing_method { get; set; }
            public String threshold_code { get; set; }
            public String in_action { get; set; }
            public String in_action_by { get; set; }
            public String? out_msg { get; set; }
            public Int16? out_result { get; set; }
        }

        public class Recondataset
        {
            public Int16? in_recondataset_gid { get; set; }
            public String? in_recon_code { get; set; }
            public String? in_dataset_code { get; set; }
            public String? in_dataset_type { get; set; }
            public String? in_parent_dataset_code { get; set; }
            public String? in_active_status { get; set; }
            public String? in_action { get; set; }
            public String? in_user_code { get; set; }
            public String? out_msg { get; set; }
            public Int16? out_result { get; set; }
        }

        public class getReconDataMappingList
        {
            public String? in_recon_code { get; set; }
            public String? in_recon_field_name { get; set; }
            public String? in_dataset_code { get; set; }
        }

        public class getCondition
        {
            public String? in_condition_type { get; set; }
            public String? in_field_type { get; set; }
            public String? in_recon_code { get; set; }

        }

        public class getdataagainsRecon
        {
            public String? in_recon_code { get; set; }
        }

        public class getFieldAgainstReconList
        {
            public String? in_recon_code { get; set; }
        }

        public class getruleagainstRecon
        {
            public String? in_recon_code { get; set; }
            // public String? in_rule_apply_on { get; set; }
        }

        public class Reconagainsttypecode
        {
            public string? in_recontype_code { get; set; }
        }

        public class Report_model
        {
            public int report_gid { get; set; }
            public string report_desc { get; set; }
            public string report_isremoved { get; set; }
            public int reportparam_gid { get; set; }
            public string report_code { get; set; }
            public int Recongid { get; set; }
            public string Recon_gid { get; set; }
            public string Trandate { get; set; }
            public int reportparam_code { get; set; }
            public string reportparam_value { get; set; }
            public int report_giddrop { get; set; }
            public bool in_outfile_flag { get; set; }
            public bool resultset_flag { get; set; }
            public string table_name { get; set; }
            public string Report_condition { get; set; }
            public int valuedrop { get; set; }

            public string account1_desc { get; set; }
            public string tran_date { get; set; }
            public string status_flag { get; set; }

            public int koid { get; set; }
            public string kodate { get; set; }
            public string reconname { get; set; }
            public string rulename { get; set; }
            public string mappingdesctype { get; set; }
            public string matchoff_type { get; set; }
            public string Knockoffby { get; set; }
            public string Knockoffamount { get; set; }
            public string review { get; set; }

            public string period_from { get; set; }
            public string period_to { get; set; }
            public string file_type { get; set; }
            public string filetype_desc { get; set; }
            public string import_date { get; set; }
            public int file_gid { get; set; }
            public string file_name { get; set; }

            public string particular { get; set; }
            public string amount { get; set; }
            public string accmode { get; set; }
            public string bal_amount { get; set; }
            public int brs_gid { get; set; }
            public int recon_gid { get; set; }
            public string rec_id { get; set; }

            public string user_code { get; set; }
            public int result { get; set; }
            public string msg { get; set; }

            public int process_gid { get; set; }
            public string ProcessName { get; set; }
            public string start_date { get; set; }
            public string end_date { get; set; }
            public string InitiatedBy { get; set; }
            public string process_status { get; set; }
            public string process_status_desc { get; set; }
            public string ip_address { get; set; }

            public int sessiongid { get; set; }
            public int pageno { get; set; }
            public int pagesize { get; set; }
            public int count { get; set; }
            public string update_flag { get; set; }
            public string active_status { get; set; }
            public string recontype { get; set; }

            public string recontallied { get; set; }
            public string recondaily_gid { get; set; }
            public int no_of_recons { get; set; }



        }

        public class cloneReconModel
        {
            public string in_recon_name { get; set; }
            public string in_clone_recon_code { get; set; }
            public string in_datasetmap { get; set; }

        }

        public class cloneReconDatasetModel
        {
            public string in_recon_code { get; set; }
            public string in_dataset_code { get; set; }
            public string in_dataset_type { get; set; }
            public string in_parent_dataset_code { get; set; }
            public string in_clone_recon_code { get; set; }
            public string in_clone_dataset_code { get; set; }
        }

        public class MonthendReportModel
        {
            public string in_recon_code { get; set; }
            public string in_tran_date { get; set; }
        }

        public class openingbalanceDatasetModel
        {
            public string in_recon_code { get; set; }
        }

        public class ArcheiveReconobj
        {
            public string in_recon_code { get; set; }
            public string in_user_code { get; set; }
        }
        public class getDSConditionModel
        {
            public String? in_condition_type { get; set; }
            public String? in_field_type { get; set; }
            public String? in_dataset_code { get; set; }

        }
    }
}
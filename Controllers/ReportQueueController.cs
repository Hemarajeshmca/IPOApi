using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using ReconDataLayer;
using IPOApi.Models;
using IPOApi.Services;
using IPOApi.Services.Interface;
using System.Data;
using IPOApi.STADataAccess;

namespace Recon_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportQueueController : ControllerBase
    {
        private readonly IReportQueueService _reportQueueService;
        private IConfiguration _configuration;
        DataTable response = new DataTable();
        DataSet ds = new DataSet();
        DataTable result = new DataTable();
        List<IDbDataParameter>? parameters;
        public ReportQueueController(IReportQueueService reportQueueService, IConfiguration configuration)
        {
            _reportQueueService = reportQueueService;
            _configuration = configuration;
        }


        [HttpPost("setReportqueue")]
        public IActionResult setReportqueue([FromBody] ReportQueueModel.reportqueue objReportqueuemodel)
        {
            //constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            IPOApi.Models.UserManagementModel.headerValue header_value = new UserManagementModel.headerValue();
            try
            {
                string jsonString = JsonConvert.SerializeObject(objReportqueuemodel);
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = _reportQueueService.setReportqueueservice(objReportqueuemodel, jsonString, header_value);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("setReportqueuewithdatamodel")]
        public IActionResult setReportqueuewithdatamodel([FromBody] ReportQueueModel.DataModel objDataModel)
        {
            //constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            UserManagementModel.headerValue header_value = new UserManagementModel.headerValue();
            try
            {

                string jsonString = JsonConvert.SerializeObject(objDataModel);
                string rawJson = JsonConvert.SerializeObject(objDataModel.Dataset1);

                // clean up if double-serialized
                if (rawJson.StartsWith("\"["))
                {
                    rawJson = JsonConvert.DeserializeObject<string>(rawJson);
                }

                List<ReportQueueModel.reportqueue> mappedList =
                       JsonConvert.DeserializeObject<List<ReportQueueModel.reportqueue>>(rawJson);

                ReportQueueModel.reportqueue mappedModel = mappedList.FirstOrDefault();

                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = _reportQueueService.setReportqueueservice(mappedModel, jsonString, header_value);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("reportScheduler")]
        public IActionResult Reportscheduler()
        {
            string constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            var koqueue_gid = 0;
            var scheduled_by = "";
            UserManagementModel.headerValue header_value = new UserManagementModel.headerValue();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = _reportQueueService.getReportqueueservice(header_value);
                if (Convert.ToInt32(response.Rows[0]["koqueue_gid"]) > 0)
                {
                    koqueue_gid = Convert.ToInt32(response.Rows[0]["koqueue_gid"]);
                    UpdatekoqueueStatus(koqueue_gid, "P", "Inprocess", constring, header_value.user_code);
                    scheduled_by = Convert.ToString(response.Rows[0]["scheduled_by"]);
                    header_value.user_code = scheduled_by;
                    var koQuery = Convert.ToString(response.Rows[0]["ko_query"]);
                    bool hasDataset1 = koQuery.Contains("\"Dataset1\"", StringComparison.OrdinalIgnoreCase);

                    if (Convert.ToString(response.Rows[0]["queue_type"]) == "Report")
                    {
                        if (hasDataset1)
                        {
                            ReportModel.ReportDataModel objDataModel = JsonConvert.DeserializeObject<ReportModel.ReportDataModel>(Convert.ToString(response.Rows[0]["ko_query"]));
                            if (objDataModel?.Dataset1 != null)
                            {
                                List<ReportQueueModel.reportqueue> objReportqueuemodel =
                                JsonConvert.DeserializeObject<List<ReportQueueModel.reportqueue>>(objDataModel.Dataset1);

                                if (objReportqueuemodel != null)
                                {

                                    if (objReportqueuemodel[0].in_outputfile_type.ToLower() == "xlsx")
                                    {
                                        ReportService.generatedynamicReportservice_new(objDataModel, constring, header_value);
                                    }
                                    else if (objReportqueuemodel[0].in_outputfile_type.ToLower() == "csv")
                                    {
                                        ReportService.generatedynamicReportservice_new(objDataModel, constring, header_value);
                                    }
                                }
                            }
                        }
                        else
                        {
                            ReportModel.generatedynamicReport_typeCmodel objReportqueuemodel1 = JsonConvert.DeserializeObject<ReportModel.generatedynamicReport_typeCmodel>(Convert.ToString(response.Rows[0]["ko_query"]));
                            ReportModel.generatedynamicReportmodel objReportqueuemodel = JsonConvert.DeserializeObject<ReportModel.generatedynamicReportmodel>(Convert.ToString(response.Rows[0]["ko_query"]));
                            if (objReportqueuemodel != null && objReportqueuemodel.in_reporttemplate_code == "")
                            {

                                if (objReportqueuemodel.in_outputfile_type.ToLower() == "xlsx")
                                {
                                    ReportService.generatedynamicReportservice(objReportqueuemodel, constring, header_value);
                                }
                                else if (objReportqueuemodel.in_outputfile_type.ToLower() == "csv")
                                {
                                    ReportService.generatedynamicReportservice(objReportqueuemodel, constring, header_value);
                                }
                            }
                            else if (objReportqueuemodel1 != null)
                            {

                                if (objReportqueuemodel1.in_outputfile_type.ToLower() == "xlsx")
                                {
                                    ReportService.generatedynamicReport_typeCservice(objReportqueuemodel1, constring, header_value);
                                }
                                else if (objReportqueuemodel.in_outputfile_type.ToLower() == "csv")
                                {
                                    ReportService.generatedynamicReportservice(objReportqueuemodel, constring, header_value);
                                }

                            }
                        }
                    }
                    UpdatekoqueueStatus(koqueue_gid, "C", "Completed", constring, header_value.user_code);
                }
                else
                {

                }
                return Ok();
            }
            catch (Exception e)
            {
                UpdatekoqueueStatus(koqueue_gid, "F", e.Message, constring, header_value.user_code);
                return Problem(title: e.Message);
            }
        }

        [HttpPost]
        public string UpdatekoqueueStatus(Int32 koqueue_gid, string koqueue_status, string koqueue_remark, string constring, string user_code)
        {
            try
            {
                DBManager dbManager = new DBManager(constring);
                Dictionary<string, Object> values = new Dictionary<string, object>();
                MySqlDataAccess con = new MySqlDataAccess("");
                parameters = new List<IDbDataParameter>();
                //int getjobId = Convert.ToInt32(job_id.ToString());
                parameters.Add(dbManager.CreateParameter("in_koqueue_gid", koqueue_gid, DbType.Int64));
                parameters.Add(dbManager.CreateParameter("in_koqueue_status", koqueue_status, DbType.String));
                parameters.Add(dbManager.CreateParameter("in_koqueue_remark", koqueue_remark, DbType.String));
                parameters.Add(dbManager.CreateParameter("out_msg", "out", DbType.String, ParameterDirection.Output));
                parameters.Add(dbManager.CreateParameter("out_result", "out", DbType.String, ParameterDirection.Output));
                ds = dbManager.execStoredProcedure("pr_upd_koqueue", CommandType.StoredProcedure, parameters.ToArray());
                result = ds.Tables[0];
                string outMsgValue = parameters[2].Value.ToString();
                return outMsgValue;
            }
            catch (Exception ex)
            {
                CommonHeader objlog = new CommonHeader();
                objlog.commonDataapi("", "SP", ex.Message + "Param:" + JsonConvert.SerializeObject(koqueue_gid), "pr_upd_koqueue", "", constring);
                return "failed";
            }
        }
    }
}

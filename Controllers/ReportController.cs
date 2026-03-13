using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static IPOApi.Models.ReconModel;
using static IPOApi.Models.ReportModel;
using UserHeader = IPOApi.Models.UserManagementModel.headerValue;
using IPOApi.Services;
using IPOApi.Models;
using System.Data;

namespace IPOApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
		private IConfiguration _configuration;
		public ReportController(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		string constring = "";
		[HttpPost("generatereport")]
        public IActionResult generatereport(generatereportmodel objgeneratereportmodel)
        {
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            UserHeader header_value = new UserHeader();
            DataTable response = new DataTable();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = ReportService.generatereportservice(objgeneratereportmodel, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }


        [HttpPost("reconbetweenacc")]
        public IActionResult reconbetweenacc(reconbetweenaccmodel objreconbetweenaccmodel)
        {
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataTable response = new DataTable();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = ReportService.reconbetweenaccservice(objreconbetweenaccmodel, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("reconwithinacc")]
        public IActionResult reconwithinacc(reconwithinaccmodel objreconwithinaccmodel)
        {
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataTable response = new DataTable();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = ReportService.reconwithinaccservice(objreconwithinaccmodel, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }


		[HttpPost("getreportlist")]
		public IActionResult getreportlist()
		{
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataTable response = new DataTable();
			try
			{
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				response = ReportService.getreportlistservice(header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}

		[HttpPost("getreportparamlist")]
		public IActionResult getreportparamlist(reportparamlistmodel objreportparamlistmodel)
		{
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataTable response = new DataTable();
			try
			{
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				response = ReportService.getreportparamlistservice(objreportparamlistmodel, header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}
		[HttpPost("getreportparamlistrecon")]
		public IActionResult getreportparamlistrecon(reportparamlistmodel objreportparamlistmodel)
		{
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataTable response = new DataTable();
			try
			{
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				response = ReportService.getreportparamlistreconservice(objreportparamlistmodel, header_value, constring);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}
		[Route("ExectionReport")]
        [HttpPost]
        public IActionResult ExectionReport(Report_model user)
        {

            //DataTable response = new DataTable();
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            string[] response = { };
            try
            {
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				var getIpAddress = Request.Headers.TryGetValue("ip_address", out var ip_address) ? ip_address.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				header_value.ip_address = getIpAddress;
				response = ReportService.ExectionReport(user, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);

            }
        }

        [Route("MonthendReport")]
        [HttpPost]
        public async Task<IActionResult> MonthendReport(MonthendReportModel objMonthendReport)
        {
            DataSet ds = new DataSet();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                ds = await ReportService.MonthendReportService(objMonthendReport, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(ds, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);

            }
        }


		[Route("getReportTemplateList")]
		[HttpPost]
		public IActionResult getReportTemplateList(getReportTemplateListModel objgetReportTemplateListModel)
		{
			DataTable dt = new DataTable();
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            try
			{
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				dt = ReportService.getReportTemplateListService(objgetReportTemplateListModel, constring, header_value);
				var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);

			}
		}


		[Route("reportTemplate")]
		[HttpPost]
		public IActionResult reportTemplate(reportTemplateModel objreportTemplate)
		{
			DataTable dt = new DataTable();
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            try
			{
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				dt = ReportService.reportTemplateService(objreportTemplate, constring, header_value);
				var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);

			}
		}


		[Route("fetchReportTemplate")]
		[HttpPost]
		public IActionResult fetchReportTemplate(fetchReportTemplateModel objfetchReportTemplate)
		{
			DataSet ds = new DataSet();
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            try
			{
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				ds = ReportService.fetchReportTemplateService(objfetchReportTemplate, constring, header_value);
				var serializedProduct = JsonConvert.SerializeObject(ds, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}


		[Route("reporttemplatefilter")]
		[HttpPost]
		public IActionResult reporttemplatefilter(reporttemplatefilterModel objreporttemplatefilter)
		{
			DataTable dt = new DataTable();
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            try
			{
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				dt = ReportService.reporttemplatefilterService(objreporttemplatefilter, constring, header_value);
				var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);

			}
		}

        #region

        // pr_run_pagereport

        [Route("runPageReport")]
        [HttpPost]
        public IActionResult runPageReport(runPageReportModel objrunPageReport)
        {
            DataTable dt = new DataTable();
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                var getIpAddress = Request.Headers.TryGetValue("ip_address", out var ip_address) ? ip_address.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                header_value.ip_address = getIpAddress;
                dt = ReportService.runPageReportService(objrunPageReport, constring, header_value);
                var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);

            }
        }

        #endregion

        #region

        [Route("getPaginationreport")]
        [HttpPost]
        public IActionResult getPaginationreport()
        {
            DataTable dt = new DataTable();
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                var getIpAddress = Request.Headers.TryGetValue("ip_address", out var ip_address) ? ip_address.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                header_value.ip_address = getIpAddress;
                dt = ReportService.getPaginationreportService(constring, header_value);
                var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);

            }
        }
        #endregion

        #region

        [Route("getPageNoReport")]
        [HttpPost]
        public IActionResult getPageNoReport(getPageNoReportModel objgetPageNoReport)
        {
            DataTable dt = new DataTable();
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                var getIpAddress = Request.Headers.TryGetValue("ip_address", out var ip_address) ? ip_address.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                header_value.ip_address = getIpAddress;
                dt = ReportService.getPageNoReportService(objgetPageNoReport, constring, header_value);
                var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);

            }
        }

        #endregion

        #region
        [Route("cloneReportTemplate")]
        [HttpPost]
        public IActionResult cloneReportTemplate(cloneReportTemplateModel objcloneReportTemplate)
        {
            DataTable dt = new DataTable();
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                var getIpAddress = Request.Headers.TryGetValue("ip_address", out var ip_address) ? ip_address.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                header_value.ip_address = getIpAddress;
                dt = ReportService.cloneReportTemplateService(objcloneReportTemplate, constring, header_value);
                var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);

            }
        }
        #endregion

        #region  reporttemplatefield

        [Route("reporttemplatefield")]
        [HttpPost]
        public IActionResult reporttemplatefield(reporttemplatefieldModel objreporttemplatefield)
        {
            DataTable dt = new DataTable();
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                var getIpAddress = Request.Headers.TryGetValue("ip_address", out var ip_address) ? ip_address.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                header_value.ip_address = getIpAddress;
                dt = ReportService.reporttemplatefieldService(objreporttemplatefield, constring, header_value);
                var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);

            }
        }
        #endregion



        #region reporttemplatesorting
        [Route("reporttemplatesorting")]
        [HttpPost]
        public IActionResult reporttemplatesorting(reporttemplatesortingModel objreporttemplatesorting)
        {
            DataTable dt = new DataTable();
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                var getIpAddress = Request.Headers.TryGetValue("ip_address", out var ip_address) ? ip_address.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                header_value.ip_address = getIpAddress;
                dt = ReportService.reporttemplatesortingService(objreporttemplatesorting, constring, header_value);
                var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);

            }
        }


        #endregion


        #region

        [Route("uploadreporttempletefile")]
        [HttpPost]
        public IActionResult uploadreporttempletefile(uploadreporttempletefileModel objuploadreporttempletefile)
        {
            DataTable dt = new DataTable();
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                var getIpAddress = Request.Headers.TryGetValue("ip_address", out var ip_address) ? ip_address.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                header_value.ip_address = getIpAddress;
                dt = ReportService.uploadreporttempletefileService(objuploadreporttempletefile, constring, header_value);
                var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);

            }
        }



        #endregion


        [HttpPost("generatedynamicreport")]
        public IActionResult generatedynamicreport(generatedynamicReportmodel objgeneratedynamicReport)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataTable response = new DataTable();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = ReportService.generatedynamicReportservice(objgeneratedynamicReport, constring, header_value);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }


        [HttpPost("generatedynamicreport_new")]
		public IActionResult generatedynamicreport_new(ReportModel.ReportDataModel objDataModel)
		{
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataTable response = new DataTable();
			try
			{
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				response = ReportService.generatedynamicReportservice_new(objDataModel, constring, header_value);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}

        //customReport_brsSummary

        [HttpPost("customReport_brsSummary")]
        public IActionResult customReport_brsSummary(customReport_brsSummaryModel objbrsSummaryModel)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            UserHeader header_value = new UserHeader();
            //headerValue header_value = new headerValue();
            DataSet response = new DataSet();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = ReportService.customReport_brsSummaryservice(objbrsSummaryModel, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

		//generatedynamicReport_typeC

		[HttpPost("generatedynamicReport_typeC")]
		public IActionResult generatedynamicReport_typeC(generatedynamicReport_typeCmodel objgeneratedynamicReport)
		{
			constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataSet response = new DataSet(); 
            try
			{
				var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
				var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
				var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
				header_value.user_code = getvalue;
				header_value.lang_code = getlangCode;
				header_value.role_code = getRoleCode;
				response = ReportService.generatedynamicReport_typeCservice(objgeneratedynamicReport, constring, header_value);
				var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
				return Ok(serializedProduct);
			}
			catch (Exception e)
			{
				return Problem(title: e.Message);
			}
		}
        
        [HttpPost("updateOncheckquery")]
        public IActionResult updateOncheckquery(updateTemplateStatusOncheckqueryModel objcheckQuery)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataTable response = new DataTable();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = ReportService.updateOncheckquery(objcheckQuery, constring, header_value);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }
        [HttpPost("checkQuery")]
        public IActionResult checkQuery(checkQueryModel objcheckQuery)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataTable response = new DataTable();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = ReportService.checkQueryService(objcheckQuery, constring, header_value);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }
        [HttpPost("resultSet")]
        public IActionResult resultSet(ResultSetModel objResultset)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataSet response = new DataSet();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = ReportService.resultSetService(objResultset, constring, header_value);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }
        [HttpPost("reportCreation")]
        public IActionResult reportCreation(ResultSetModel.report objReport)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataSet response = new DataSet();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = ReportService.reportCreationService(objReport, constring, header_value);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }
		
		[HttpPost("getstandardreportlist")]
        public IActionResult getstandardreportlist(getsreport objgetsreportlist)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataTable response = new DataTable();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = ReportService.getstandardreportlistservice(objgetsreportlist,header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }
         //Pandiaraj 14-08-2025
        [Route("getRoleReportTemplateList")]
        [HttpPost]
        public IActionResult getRoleReportTemplateList(getReportTemplateListModel objgetReportTemplateListModel)
        {
            DataTable dt = new DataTable();
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            try
            {
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                dt = ReportService.getRoleReportTemplateListService(objgetReportTemplateListModel, constring, header_value);
                var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);

            }
        }
    }
}

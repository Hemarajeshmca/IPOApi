using Microsoft.AspNetCore.Mvc;
using IPOApi.Models;
using IPOApi.Services;
using System.Data;
// prefer fully-qualified headerValue to avoid ambiguous type name

namespace IPOApi.Controllers
{
    public class AuditController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuditController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("auditLog")]
        public IActionResult auditLog([FromBody] AuditLogEntryModel audit)
        {
            try
            {
                string constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
                IPOApi.Models.headerValue header_value = new IPOApi.Models.headerValue();

                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                var getIp = Request.Headers.TryGetValue("ip_address", out var ip_addr) ? ip_addr.First() : "";

                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                header_value.ip_address = getIp;

                DataTable response = AuditService.SaveAudit(audit, header_value, constring);
                return Ok(response);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }
    }
}

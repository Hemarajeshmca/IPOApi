using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using IPOApi.Services;
using UserHeader = IPOApi.Models.UserManagementModel.headerValue;
using System.Data;
using System.Linq;
using IPOApi.Models;

namespace IPOApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private IConfiguration _configuration;
        public CommonController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        string constring = "";
        [HttpPost("errorLog")]
        public void errorLog(CommonModel.errorlogModel objerrorlog)
        {
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataTable response = new DataTable();
            try
            {
                constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = CommonService.Commonservice(objerrorlog, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                //return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                //return Problem(title: e.Message);
            }
        }

        [HttpPost("configvalue")]
        public IActionResult configvalue(CommonModel.configvalueModel objconfigvalue)
        {
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataTable response = new DataTable();
            try
            {
                constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = CommonService.configvalueservice(objconfigvalue, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }

        [HttpPost("roleconfig")]
        public IActionResult roleconfig(CommonModel.roleconfig objconfigvalue)
        {
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataTable response = new DataTable();
            try
            {
                constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = CommonService.roleconfig_srv(objconfigvalue, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }
        [HttpPost("reconmindate")]
        public IActionResult reconmindate(CommonModel.reconmindate objconfigvalue)
        {
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataTable response = new DataTable();
            try
            {
                constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = CommonService.reconmindate_srv(objconfigvalue, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }
        [HttpPost("Schedulerupload")]
        public IActionResult Scheduleruploadfile(IFormFile file, string in_file_path, string initiated_by)
        {
            string msg = "";
            var src_filename = "";
            //try
            //{
            if (file != null && file.Length > 0)
            {
                if (!Directory.Exists(in_file_path))
                {
                    Directory.CreateDirectory(in_file_path);
                }
                src_filename = file.FileName;

                var targetFilePath = System.IO.Path.Combine(in_file_path, src_filename);
                using (var stream = new FileStream(targetFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                msg = "File uploaded and saved successfully...";
            }
            else
            {
                msg = "No file was uploaded.";
            }
            var serializedProduct = msg;
            return Ok(serializedProduct);
        }
        [HttpPost("GetFiles")]
        public IActionResult GetFiles(string folder_path)
        {
            string folderPath = folder_path;
            var directories = Directory.GetDirectories(folderPath)
                    .Select(dirPath => new FileSystemItem
                    {
                        Name = Path.GetFileName(dirPath),
                        FullPath = dirPath,
                        Type = "Folder",
                        Created = Directory.GetCreationTime(dirPath),
                        SizeBytes = null
                    });

            var files = Directory.GetFiles(folderPath)
                .Select(filePath => new FileSystemItem
                {
                    Name = Path.GetFileName(filePath),
                    FullPath = filePath,
                    Type = "File",
                    Created = System.IO.File.GetCreationTime(filePath),
                    SizeBytes = new FileInfo(filePath).Length
                });

            var result = directories.Concat(files).ToList();

            return Ok(result);
        }
        public class FileSystemItem
        {
            public string Name { get; set; }
            public string FullPath { get; set; }
            public string Type { get; set; } // "File" or "Folder"
            public DateTime Created { get; set; }
            public long? SizeBytes { get; set; } // Nullable: only used for files
        }

        [HttpPost("reportpermissionconfig")]
        public IActionResult reportpermissionconfig(CommonModel.reportvalidatemodel objconfigvalue)
        {
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataTable response = new DataTable();
            try
            {
                constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = CommonService.reportconfig_srv(objconfigvalue, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }
        [HttpGet("scheduledownload")]
        public IActionResult DownloadFile([FromQuery] string filePath, [FromQuery] string fileName)
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(fileName))
                return BadRequest("File path or name is missing.");

            string fullPath = Path.Combine(filePath, fileName);

            if (!System.IO.File.Exists(fullPath))
                return NotFound("File not found.");

            var fileBytes = System.IO.File.ReadAllBytes(fullPath);
            var contentType = "application/octet-stream"; // default, you can detect mime type if needed

            return File(fileBytes, contentType, fileName);
        }
        [HttpGet("pipelinetemplatedownload")]
        public IActionResult pipelinetemplatedownload([FromQuery] string pipeline_code, string file_extension, string file_name, string username)
        {
            constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
            DataTable response = new DataTable();
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            CommonModel.configvalueModel objconfigvalue = new CommonModel.configvalueModel();
            objconfigvalue.in_config_name = _configuration.GetSection("Appsettings")["template_download"].ToString();
            response = CommonService.configvalueservice(objconfigvalue, header_value, constring);
            string filePath = "";
            if (response.Rows.Count > 0)
            {
                filePath = response.Rows[0]["out_config_value"].ToString();
            }
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(file_name))
                return BadRequest("File path or name is missing.");
            string fileName = pipeline_code + file_extension;
            string fullPath = Path.Combine(filePath, fileName);

            if (!System.IO.File.Exists(fullPath))
                return NotFound("File not found.");

            var fileBytes = System.IO.File.ReadAllBytes(fullPath);
            var contentType = "application/octet-stream"; // default, you can detect mime type if needed

            return File(fileBytes, contentType, fileName);
        }
        [HttpPost("Archeivedatasetlist")]
        public IActionResult Archeivedatasetlist(CommonModel.ArcheivedatasetlistModel objconfigvalue)
        {
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataTable response = new DataTable();
            try
            {
                constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = CommonService.Archeivedatasetlist_srv(objconfigvalue, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }
        [HttpPost("archivaldatasetsave")]
        public IActionResult archivaldatasetsave(CommonModel.archivaldatasetsaveModel objconfigvalue)
        {
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataTable response = new DataTable();
            try
            {
                constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = CommonService.archivaldatasetsave_srv(objconfigvalue, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }
        [HttpPost("Archeivedatasetfetch")]
        public IActionResult Archeivedatasetfetch(CommonModel.ArcheivedatasetfetchModel objconfigvalue)
        {
            //headerValue header_value = new headerValue();
            UserHeader header_value = new UserHeader();
            DataTable response = new DataTable();
            try
            {
                constring = _configuration.GetSection("Appsettings")["ConnectionStrings"].ToString();
                var getvalue = Request.Headers.TryGetValue("user_code", out var user_code) ? user_code.First() : "";
                var getlangCode = Request.Headers.TryGetValue("lang_code", out var lang_code) ? lang_code.First() : "";
                var getRoleCode = Request.Headers.TryGetValue("role_code", out var role_code) ? role_code.First() : "";
                header_value.user_code = getvalue;
                header_value.lang_code = getlangCode;
                header_value.role_code = getRoleCode;
                response = CommonService.Archeivedatasetfetch_srv(objconfigvalue, header_value, constring);
                var serializedProduct = JsonConvert.SerializeObject(response, Formatting.None);
                return Ok(serializedProduct);
            }
            catch (Exception e)
            {
                return Problem(title: e.Message);
            }
        }
        [HttpGet("schedulefiledelete")]
        public IActionResult schedulefiledelete([FromQuery] string filePath, [FromQuery] string fileName)
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(fileName))
                return BadRequest("File path or name is missing.");

            string fullPath = Path.Combine(filePath, fileName);

            if (!System.IO.File.Exists(fullPath))
                return NotFound("File not found.");
            try
            {
                System.IO.File.Delete(fullPath);
                return Ok("File deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"File delete failed: {ex.Message}");
            }
        }
    }
}

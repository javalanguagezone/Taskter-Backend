using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Taskter.Api.Controllers
{
    [Route("api/clientconfig")]
    [ApiController]
    public class ClientConfigController : Controller
    {
        [HttpGet]
        public IActionResult GetClientConfig()
        {
            var result = new Dictionary<string, object>();
            result.Add("stsServer", "http://localhost:5000/");
            result.Add("redirect_url", "http://localhost:4200");
            result.Add("client_id", "js");
            result.Add("response_type", "code");
            result.Add("scope", "api role address openid profile");
            result.Add("post_logout_redirect_uri", "https://localhost:4200/logout");
            result.Add("start_checksession", true);
            result.Add("silent_renew", true);
            result.Add("silent_renew_url", "http://localhost:4200/silent_renew.html");
            result.Add("post_login_route", "/timeSheet");
            result.Add("forbidden_route", "/forbidden");
            result.Add("unauthorized_route", "/unauthorized");
            result.Add("log_console_warning_active", true);
            result.Add("log_console_debug_active", false);
            result.Add("max_id_token_iat_offset_allowed_in_seconds", 10);
            result.Add("apiServer", "http://localhost:50500/");
            return Ok(result);
        }
    }
}

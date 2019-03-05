using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Taskter.Api.Controllers
{
    [Route("identity")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = new HttpClient();
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:44324");
            var userInfo = await client.GetUserInfoAsync(new UserInfoRequest {
                Address = disco.UserInfoEndpoint,
                Token = accessToken
            });
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}

using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Taskter.Infrastructure.UserContext;

namespace Taskter.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/users")]
    public class UserController : ApplicationControllerBase
    {
        private readonly ICurrentUserContext _currentUserContext;

        public UserController(ICurrentUserContext currentUserContext)
        {
            _currentUserContext = currentUserContext;
        }

        [HttpGet]
        [Route("current")]
        public async Task<IActionResult> GetCurrentUser([FromHeader]string authorization)
        {
            HttpClient client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5000");
            if (disco.IsError)
            {
                throw new Exception(disco.Error);
            }

            var userInfo = await client.GetUserInfoAsync(new UserInfoRequest {
                Address = disco.UserInfoEndpoint,
                Token = authorization.Split(' ')[1]
            });
            return Ok(userInfo);
        }
    }
}
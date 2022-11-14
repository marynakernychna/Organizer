using Core.DTOs.Authentication;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(
            IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(
            [FromBody] RegistrationDTO data)
        {
            var callbackUrl = Request.GetTypedHeaders().Referer.ToString();
            await _authenticationService.RegisterAsync(data, callbackUrl);

            return Ok();
        }
    }
}

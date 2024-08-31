using HR_Management.Application.Cantracts.Identity;
using HR_Management.Application.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Authentication")]
        public async Task<ActionResult<AuthenticationResponse>> Authentication(AuthenticationRequest authenticationRequest)
        {
            var response = await _authenticationService.Authentication(authenticationRequest);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest registrationRequest)
        {
            var response = await _authenticationService.Register(registrationRequest);
            return Ok(response);
        }
    }
}

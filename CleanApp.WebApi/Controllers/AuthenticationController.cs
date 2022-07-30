using CleanApp.Application.Services;
using CleanApp.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace CleanApp.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {

            ErrorOr<AuthenticationResult> authServiceResult = _authenticationService.Register(
                FirstName: request.FirstName,
                LastName: request.LastName,
                Email: request.Email,
                Password: request.Password);


            return authServiceResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));

        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new(
                Id: Guid.NewGuid(),
                FirstName: authResult.User.FirstName,
                LastName: authResult.User.LastName,
                Email: authResult.User.Email,
                Token: authResult.Token);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {

            ErrorOr<AuthenticationResult> authServiceResult = _authenticationService.Login(
                Email: request.Email,
                Password: request.Password);

            return authServiceResult.Match(
               registerResult => Ok(MapAuthResult(registerResult)),
               errors => Problem(errors));

        }
    }
}

﻿using CleanApp.Api.Filters;
using CleanApp.Application.Services;
using CleanApp.Contracts.Authentication;

using Microsoft.AspNetCore.Mvc;

namespace CleanApp.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    //[ErrorHandlingFilter]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {

            var authResult = _authenticationService?.Register(
                FirstName: request.FirstName,
                LastName: request.LastName,
                Email: request.Email,
                Password: request.Password);

            if (authResult == null)
            {
                return BadRequest();
            }

            AuthenticationResponse response = new(
                Id: Guid.NewGuid(),
                FirstName: authResult.User.FirstName,
                LastName: authResult.User.LastName,
                Email: authResult.User.Email,
                Token: authResult.Token);

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {

            var authResult = _authenticationService?.Login(
                Email: request.Email,
                Password: request.Password);

            if (authResult == null)
            {
                return BadRequest();
            }

            AuthenticationResponse response = new(
                Id: Guid.NewGuid(),
                FirstName: authResult.User.FirstName,
                LastName: authResult.User.LastName,
                Email: authResult.User.Email,
                Token: authResult.Token);

            return Ok(response);
        }
    }
}

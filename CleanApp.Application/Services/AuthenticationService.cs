using CleanApp.Application.Common.Interfaces;

namespace CleanApp.Application.Services;

public class AuthenticationService : IAuthenticationService
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string Email, string Password)
    {
        return new AuthenticationResult(
            Id: Guid.NewGuid(),
            FirstName: "FirstName",
            LastName: "LastName",
            Email: Email,
            Token: "token"
        );
    }

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {

        //check if user already exists 

        //create user (generate unique ID)

        //generate JWT token
        var jwtToken = _jwtTokenGenerator.GenerateJwtToken(userId: Guid.NewGuid(), FirstName, LastName);

        return new AuthenticationResult(
            Id: Guid.NewGuid(),
            FirstName: FirstName,
            LastName: LastName,
            Email: Email,
            Token: jwtToken
        );
    }
}


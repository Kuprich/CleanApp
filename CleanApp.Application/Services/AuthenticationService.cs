namespace CleanApp.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult Login(string Email, string Password)
    {
        return new AuthenticationResult(
            Id: Guid.NewGuid(),
            FirstName: "FirstName",
            LastName: "LastName",
            Email: Email,
            Token: "password token"
        );
    }

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        return new AuthenticationResult(
            Id: Guid.NewGuid(),
            FirstName: FirstName,
            LastName: LastName,
            Email: Email,
            Token: "password token"
        );
    }
}


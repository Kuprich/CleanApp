using ErrorOr;

namespace CleanApp.Application.Services;

public interface IAuthenticationService
{
    public ErrorOr<AuthenticationResult> Login(string Email, string Password);
    public ErrorOr<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password);

}


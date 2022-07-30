using CleanApp.Application.Common.Interfaces.Services;
using CleanApp.Application.Common.Persistence;
using CleanApp.Domain.Common.Errors;
using ErrorOr;

namespace CleanApp.Application.Services;

public class AuthenticationService : IAuthenticationService
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        //1. Validate the user exists
        var user = _userRepository.GetUserByEmail(email);

        if (user == null)
        {
            return Errors.Authentiaction.InvalidCredentials;
        }

        //2. Validate user password
        if (user.Password != password)
        {
            return Errors.Authentiaction.InvalidCredentials;
        }

        var jwtToken = _jwtTokenGenerator.GenerateJwtToken(user);

        return new AuthenticationResult(user, jwtToken);
    }

    public ErrorOr<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password)
    {

        //1. Check if user doesn't exist
        var user = _userRepository.GetUserByEmail(Email);

        if (user != null)
        {
            return Errors.User.DublicateEmail;
        }

        //2. Create user (generate unique ID)

        user = new()
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Password = Password
        };

        _userRepository.Add(user);

        //3. Generate JWT token
        var jwtToken = _jwtTokenGenerator.GenerateJwtToken(user);

        return new AuthenticationResult(user, jwtToken);
    }
}


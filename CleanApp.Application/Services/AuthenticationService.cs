using CleanApp.Application.Common.Interfaces.Services;
using CleanApp.Application.Common.Persistence;

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

    public AuthenticationResult Login(string email, string password)
    {
        //1. Validate the user exists
        var user = _userRepository.GetUserByEmail(email);

        if (user == null)
        {
            throw new Exception("user with given Email doesn't exist");
        }

        //2. Validate user password
        if (user.Password != password)
        {
            throw new Exception("Password inccorrect");
        }

        var jwtToken = _jwtTokenGenerator.GenerateJwtToken(user);

        return new AuthenticationResult(user, jwtToken);
    }

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {

        //1. Check if user doesn't exist
        var user = _userRepository.GetUserByEmail(Email);

        if (user != null)
        {
            throw new Exception("user with given Email already exists");
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


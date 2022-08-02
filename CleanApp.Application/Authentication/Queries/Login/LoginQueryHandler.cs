using CleanApp.Application.Common.Interfaces.Services;
using CleanApp.Application.Common.Persistence;
using CleanApp.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace CleanApp.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        //1. Validate the user exists
        var user = _userRepository.GetUserByEmail(request.Email);

        if (user == null)
        {
            ErrorOr<AuthenticationResult> error = Errors.Authentiaction.InvalidCredentials;
            return Task.FromResult(error);
        }

        //2. Validate user password
        if (user.Password != request.Password)
        {
            ErrorOr<AuthenticationResult> error = Errors.Authentiaction.InvalidCredentials;
            return Task.FromResult(error);
        }

        var jwtToken = _jwtTokenGenerator.GenerateJwtToken(user);


        ErrorOr<AuthenticationResult> AuthResult = new AuthenticationResult(user, jwtToken);

        return Task.FromResult(AuthResult);
    }
}

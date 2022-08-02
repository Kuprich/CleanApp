using CleanApp.Application.Common.Interfaces.Services;
using CleanApp.Application.Common.Persistence;
using CleanApp.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace CleanApp.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : 
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator, 
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand request,
        CancellationToken cancellationToken)
    {
        //1. Check if user doesn't exist
        var user = _userRepository.GetUserByEmail(request.Email);

        if (user != null)
        {
            ErrorOr<AuthenticationResult> error = Errors.User.DublicateEmail;
            return Task.FromResult(error);
        }

        //2. Create user (generate unique ID)

        user = new()
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        };

        _userRepository.Add(user);

        //3. Generate JWT token
        var jwtToken = _jwtTokenGenerator.GenerateJwtToken(user);

        ErrorOr<AuthenticationResult> AuthResult = new AuthenticationResult(user, jwtToken);

        return Task.FromResult(AuthResult);
    }
}

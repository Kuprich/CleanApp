using ErrorOr;
using MediatR;

namespace CleanApp.Application.Authentication.Commands.Register;

public record RegisterCommand (
string FirstName,
string LastName,
string Email,
string Password) : IRequest<ErrorOr<AuthenticationResult>>;

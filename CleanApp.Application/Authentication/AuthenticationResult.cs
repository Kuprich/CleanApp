using CleanApp.Domain.Entities;

namespace CleanApp.Application.Authentication;

public record AuthenticationResult(
    User User,
    string Token);


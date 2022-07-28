using CleanApp.Domain.Entities;

namespace CleanApp.Application.Services;

public record AuthenticationResult(
    User User,
    string Token);


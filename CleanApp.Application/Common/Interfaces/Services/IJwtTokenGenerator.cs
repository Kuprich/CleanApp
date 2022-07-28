using CleanApp.Domain.Entities;

namespace CleanApp.Application.Common.Interfaces.Services;

public interface IJwtTokenGenerator
{
    string GenerateJwtToken(User user);
}

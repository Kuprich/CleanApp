namespace CleanApp.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateJwtToken(Guid userId, string firstName, string lastName);
}

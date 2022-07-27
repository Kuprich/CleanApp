namespace CleanApp.Infrastructure.Authentication;

public class JwtSettings
{
    public const string sectionName = "JwtSettings";

    public string? Secret { get; init; } 
    public string? Issuer { get; init; }
    public int ExpiryMinutes { get; init; }
    public string? Audience { get; init;}
}

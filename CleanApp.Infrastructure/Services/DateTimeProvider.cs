using CleanApp.Application.Common.Interfaces.Authentication;

namespace CleanApp.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.Now;
}

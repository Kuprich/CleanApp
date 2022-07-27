using CleanApp.Application.Common.Interfaces;

namespace CleanApp.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.Now;
}

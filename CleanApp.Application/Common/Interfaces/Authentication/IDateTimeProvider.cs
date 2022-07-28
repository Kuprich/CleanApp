namespace CleanApp.Application.Common.Interfaces.Authentication;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}

using ErrorOr;

namespace CleanApp.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentiaction
    {
        public static Error InvalidCredentials => Error.Conflict(
            code: "Authentiaction.InvalidCredentials",
            description: "Invalid Credentials");
    }
}


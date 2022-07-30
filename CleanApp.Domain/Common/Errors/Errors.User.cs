using ErrorOr;

namespace CleanApp.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DublicateEmail => Error.Conflict(
            code: "User.DublicateEmail",
            description: "Email already exist");
    }
}


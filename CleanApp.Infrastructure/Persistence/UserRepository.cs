using CleanApp.Application.Common.Persistence;
using CleanApp.Domain.Entities;

namespace CleanApp.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static List<User> _users = new ();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }
}

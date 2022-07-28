using CleanApp.Domain.Entities;

namespace CleanApp.Application.Common.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}

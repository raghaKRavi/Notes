using Notes.Application.Common.Interfaces.Presistence;
using Notes.Domain.Entity;

namespace Notes.Infrastructure.Presistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUser(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}
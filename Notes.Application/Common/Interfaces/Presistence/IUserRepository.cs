using Notes.Domain.Entity;

namespace Notes.Application.Common.Interfaces.Presistence;

public interface IUserRepository
{
    User? GetUser(string email);
    void Add(User user);
}
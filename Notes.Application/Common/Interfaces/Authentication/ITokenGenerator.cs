using Notes.Domain.Entity;

namespace Notes.Application.Common.Interfaces.Authentication;

public interface ITokenGenerator
{
    string GenerateToken(User user);
}
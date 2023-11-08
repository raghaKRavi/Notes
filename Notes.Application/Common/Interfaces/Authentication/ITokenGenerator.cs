namespace Notes.Application.Common.Interfaces.Authentication;

public interface ITokenGenerator
{
    string GenerateToken(Guid userId, string firstName, string LastName);
}
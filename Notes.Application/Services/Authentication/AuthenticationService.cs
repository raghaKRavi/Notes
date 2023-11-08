using Notes.Application.Common.Interfaces.Authentication;

namespace Notes.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly ITokenGenerator _jwtTokenGenerator;

    public AuthenticationService(ITokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            email,
            "token"
        );
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {

        //TODO: Check if user exist
        //Todo: Create new user

        //Generate Token
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

         return new AuthenticationResult(
            userId,
            firstName,
            lastName,
            email,
            token
        );
    }
}
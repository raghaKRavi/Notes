using Notes.Application.Common.Interfaces.Authentication;
using Notes.Application.Common.Interfaces.Presistence;
using Notes.Application.Common.Interfaces.Services;
using Notes.Domain.Entity;

namespace Notes.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly ITokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public AuthenticationService(
        ITokenGenerator jwtTokenGenerator, 
        IUserRepository userRepository, 
        IDateTimeProvider dateTimeProvider
    )
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public AuthenticationResult Login(string email, string password)
    {

        //1. check if user exist
        if(_userRepository.GetUser(email) is not User user){
            throw new Exception("User email iss not available");
        }

        //2. check password
        if(user.Password != password){
            throw new Exception("Password is wrong");
        }

        //3. generate token
        var jwtToken = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            jwtToken
        );
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {

        //1. Check if user exist
        if(_userRepository.GetUser(email) is not null){
            throw new Exception("User with given email already exist!");
        }
        //2. Create new user
        var user = new User {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password,
            CreatedAt = _dateTimeProvider.UtcNow,
            ModifiedAt = _dateTimeProvider.UtcNow
        };
        _userRepository.Add(user);

        //Generate Token
        var token = _jwtTokenGenerator.GenerateToken(user);

         return new AuthenticationResult(
            user,
            token
        );
    }
}
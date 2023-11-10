
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Services.Authentication;
using Notes.Contracts.Authentication;

namespace Notes.Api.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthenticationController : ControllerBase
{

    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest registerRequest){
        var result = _authenticationService.Register(
            registerRequest.FirstName,
            registerRequest.LastName,
            registerRequest.Email,
            registerRequest.Password
            );

        var response = new AuthenticationResponse(
            result.user.Id,
            result.user.FirstName,
            result.user.LastName,
            result.user.Email,
            result.user.CreatedAt,
            result.user.ModifiedAt,
            result.Token
        );
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginRequest){

        var result = _authenticationService.Login(loginRequest.Email, loginRequest.Password);

        var response = new AuthenticationResponse(
            result.user.Id,
            result.user.FirstName,
            result.user.LastName,
            result.user.Email,
            result.user.CreatedAt,
            result.user.ModifiedAt,
            result.Token
        );
        return Ok(response);
    }

}
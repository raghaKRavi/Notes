using Notes.Domain.Entity;

namespace Notes.Application.Services.Authentication;

public record AuthenticationResult(
    User user,
    string Token
    
);
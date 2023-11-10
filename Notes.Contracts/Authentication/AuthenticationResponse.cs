namespace Notes.Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    DateTime CreatedAt,
    DateTime ModifiedAt,
    string Token
);
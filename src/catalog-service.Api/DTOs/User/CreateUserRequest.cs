namespace catalog_service.Api.DTOs.User
{
    public record CreateUserRequest
        (
        string FirstName,
        string LastName,
        string EmailAddress,
        string Password
        );
}

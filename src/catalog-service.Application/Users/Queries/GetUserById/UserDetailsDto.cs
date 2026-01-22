using System;
using System.Collections.Generic;
using System.Text;

namespace catalog_service.Application.Users.Queries.GetUserById
{
    public sealed record UserDetailsDto(
        int Id,
        string FirstName,
        string LastName,
        string EmailAddress,
        bool IsActive,
        DateTime CreatedAt
        );
}

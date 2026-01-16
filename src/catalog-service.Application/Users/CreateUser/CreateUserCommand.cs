using System;
using System.Collections.Generic;
using System.Text;

namespace catalog_service.Application.Users.CreateUser
{
    public record CreateUserCommand
    (
        string FirstName,
        string LastName,
        string EmailAddress,
        string HashPassword
    );
}

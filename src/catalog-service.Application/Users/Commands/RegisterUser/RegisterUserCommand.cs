using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace catalog_service.Application.Users.Commands.RegisterUser
{
    public sealed record RegisterUserCommand
    (
        string FirstName,
        string LastName,
        string EmailAddress,
        string HashPassword

    ) : IRequest<int>;
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace catalog_service.Application.Users.Commands.UpdateUser
{
    public sealed record UpdateUserCommand 
    (
        int Id,
        string FirstName,
        string LastName,
        string EmailAddress
    ) : IRequest<int>;
}

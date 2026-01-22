using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace catalog_service.Application.Users.Commands.UpdateUserProfile
{
    public sealed record UpdateUserProfileCommand 
    (
        int Id,
        string FirstName,
        string LastName,
        string EmailAddress
    ) : IRequest<int>;
}

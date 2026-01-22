using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace catalog_service.Application.Users.Commands.DeactivateUser
{
    public sealed record DeactivateUserCommand(int UserId) : IRequest;
}

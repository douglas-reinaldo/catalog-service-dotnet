using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace catalog_service.Application.Users.Queries.GetUserById
{
    public sealed record GetUserByIdQuery(int UserId) : IRequest<UserDetailsDto>;
}

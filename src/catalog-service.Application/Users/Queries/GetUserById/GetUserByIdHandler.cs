using catalog_service.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace catalog_service.Application.Users.Queries.GetUserById
{
    public sealed class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDetailsDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDetailsDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId);

            if (user == null) return null;
            

            return new UserDetailsDto
            (
                user.Id,
                user.FirstName,
                user.LastName,
                user.EmailAddress,
                user.IsActive,
                user.CreatedAt
            );
        }
    }
}

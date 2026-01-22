using catalog_service.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace catalog_service.Application.Users.Commands.DeactivateUser
{
    public sealed class DeactivateUserHandler : IRequestHandler<DeactivateUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeactivateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task Handle(DeactivateUserCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId);

            if (user is null)
            {
                throw new KeyNotFoundException($"User with Id {request.UserId} was not found.");
            }

            user.Deactivate();
            await _unitOfWork.CommitAsync();
        }
    }
}

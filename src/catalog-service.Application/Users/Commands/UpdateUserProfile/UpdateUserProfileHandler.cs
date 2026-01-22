using catalog_service.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace catalog_service.Application.Users.Commands.UpdateUserProfile
{
    public sealed class UpdateUserProfileHandler : IRequestHandler<UpdateUserProfileCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserProfileHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var user = _unitOfWork.UserRepository.GetByIdAsync(request.Id).Result
                ?? throw new KeyNotFoundException($"User with Id {request.Id} was not found.");

            user.Update(request.FirstName, 
                request.LastName, 
                request.EmailAddress
                );

            await _unitOfWork.CommitAsync();
            return user.Id;
        }
    }
}

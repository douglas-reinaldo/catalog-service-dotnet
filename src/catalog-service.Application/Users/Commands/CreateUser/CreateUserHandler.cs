using catalog_service.Domain.Entities;
using catalog_service.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace catalog_service.Application.Users.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateUserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            if (command == null) 
            {
                throw new ArgumentNullException(nameof(command));
            }

            var user = new User(
                command.FirstName,
                command.LastName,
                command.EmailAddress,
                command.HashPassword);

            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();

            return new CreateUserResult(user.Id!.Value);
        }

       
    }
}

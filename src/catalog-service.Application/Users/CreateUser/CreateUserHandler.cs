using catalog_service.Application.Common.Interfaces.Persistence;
using catalog_service.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace catalog_service.Application.Users.CreateUser
{
    public class CreateUserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateUserResult> Handle(CreateUserCommand command) 
        {
            var user = new User(
                command.FirstName,
                command.LastName,
                command.EmailAddress,
                command.HashPassword);

            await _userRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();

            return new CreateUserResult(user.Id);
        }
    }
}

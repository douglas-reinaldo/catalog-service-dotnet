using catalog_service.Application.Common.Interfaces.Persistence;
using catalog_service.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace catalog_service.Application.Users.CreateUser
{
    public class CreateUserHandler
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public CreateUserResult Handle(CreateUserCommand command) 
        {
            var user = new User(
                command.FirstName,
                command.LastName,
                command.EmailAddress,
                command.HashPassword);

            _userRepository.AddUser(user);
            return new CreateUserResult(user.Id);
        }
    }
}

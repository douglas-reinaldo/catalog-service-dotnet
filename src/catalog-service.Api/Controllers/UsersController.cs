using catalog_service.Api.DTOs.User;
using catalog_service.Application.Users.CreateUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace catalog_service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private CreateUserHandler _userHandler;

        public UsersController(CreateUserHandler userHandler) 
        {
            _userHandler = userHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest createUserRequest) 
        {
            var command = new CreateUserCommand
                (
                    FirstName: createUserRequest.FirstName,
                    LastName: createUserRequest.LastName,
                    EmailAddress: createUserRequest.EmailAddress,
                    HashPassword: createUserRequest.Password
                );

            var user = await _userHandler.Handle(command);
            return Ok(user);
        }
    }
}

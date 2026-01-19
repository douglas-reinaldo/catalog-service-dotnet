using catalog_service.Api.DTOs.User;
using catalog_service.Application.Users.Commands.CreateUser;
using catalog_service.Application.Users.Commands.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace catalog_service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
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

            var user = await _mediator.Send(command);
            return Created(String.Empty, user.UserId);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromBody] UpdateUserRequest updateUserRequest) 
        {
            var command = new UpdateUserCommand(
                Id: Id,
                FirstName: updateUserRequest.FirstName,
                LastName: updateUserRequest.LastName,
                EmailAddress: updateUserRequest.EmailAddress
                );

            var result = await _mediator.Send(command);
            return Ok(result.UserId);
        }
    }
}

using catalog_service.Api.DTOs.User;
using catalog_service.Application.Users.Commands.DeactivateUser;
using catalog_service.Application.Users.Commands.RegisterUser;
using catalog_service.Application.Users.Commands.UpdateUserProfile;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
            var command = new RegisterUserCommand
                (
                    FirstName: createUserRequest.FirstName,
                    LastName: createUserRequest.LastName,
                    EmailAddress: createUserRequest.EmailAddress,
                    HashPassword: createUserRequest.Password
                );

            var result = await _mediator.Send(command);
            return Created(String.Empty, result);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromBody] UpdateUserRequest updateUserRequest) 
        {
            var command = new UpdateUserProfileCommand(
                Id: Id,
                FirstName: updateUserRequest.FirstName,
                LastName: updateUserRequest.LastName,
                EmailAddress: updateUserRequest.EmailAddress
                );

            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPatch("{Id}/deactivate")]
        public async Task<IActionResult> Deactivate(int Id) 
        {
            var command = new DeactivateUserCommand(Id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

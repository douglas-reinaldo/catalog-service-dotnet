using catalog_service.Api.DTOs.User;
using catalog_service.Application.Users.Commands.DeactivateUser;
using catalog_service.Application.Users.Commands.RegisterUser;
using catalog_service.Application.Users.Commands.UpdateUserProfile;
using catalog_service.Application.Users.Queries.GetUserById;
using MediatR;
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
            var command = new RegisterUserCommand
                (
                    FirstName: createUserRequest.FirstName,
                    LastName: createUserRequest.LastName,
                    EmailAddress: createUserRequest.EmailAddress,
                    HashPassword: createUserRequest.Password
                );

            var userId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new {id = userId}, null);
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

            var userId = await _mediator.Send(command);
            return Ok(userId);
        }


        [HttpPatch("{Id}/deactivate")]
        public async Task<IActionResult> Deactivate(int Id) 
        {
            var command = new DeactivateUserCommand(Id);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var userDetails = await _mediator.Send(new GetUserByIdQuery(id));
            if (userDetails == null) return NotFound();

            return Ok(userDetails);
        }
    }
}

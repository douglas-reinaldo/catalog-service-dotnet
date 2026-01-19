using catalog_service.Api.DTOs.User;
using catalog_service.Application.Users.CreateUser;
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
    }
}

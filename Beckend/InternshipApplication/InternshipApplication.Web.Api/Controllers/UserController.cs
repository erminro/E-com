using InernshipApplication.Web.Domain;
using InternshipApplication.Web.Core.Commands.Users;

using InternshipApplication.Web.Core.Dto;
using InternshipApplication.Web.Core.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InternshipApplication.Web.Api.Controllers
{

    public class UserController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            var result = await Mediator.Send(new GetUserQuery { Id = userId });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]NewUserDto userDto)
        {

            var result = await Mediator.Send(new CreateUserCommand { NewUserDto = userDto });
            return Ok(result);
        }
        [Route("{userId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var result = await Mediator.Send(new DeleteUserCommand { Id=userId });
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto)
        {
            var command = new UpdateUserCommand { UserDto = userDto };
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
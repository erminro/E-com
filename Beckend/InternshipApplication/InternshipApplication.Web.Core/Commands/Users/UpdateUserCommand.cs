using InternshipApplication.Web.Core.Dto;
using MediatR;

namespace InternshipApplication.Web.Core.Commands.Users
{
    public class UpdateUserCommand : IRequest
    {
        public UserDto UserDto { get; set; }
    }
}

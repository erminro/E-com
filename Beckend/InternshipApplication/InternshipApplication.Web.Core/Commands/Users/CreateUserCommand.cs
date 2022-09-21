using InernshipApplication.Web.Domain;
using InternshipApplication.Web.Core.Dto;
using MediatR;

namespace InternshipApplication.Web.Core.Commands.Users
{
    public class CreateUserCommand : IRequest
    {
        public NewUserDto NewUserDto { get; set; }

    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.Commands.Users
{
    public class DeleteUserCommand:IRequest
    {

        public Guid Id { get; set; }
    }
}

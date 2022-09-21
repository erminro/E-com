using InernshipApplication.Web.Domain;
using InternshipApplication.Web.Core.Interfaces;
using InternshipApplication.Web.Core.Queries;
using InternshipApplication.Web.Core.Queries.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.QueryHandler.Users
{
    public class GetCategoryQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user= await _unitOfWork.UserRepository.Get(request.Id);
            return user;
        }
    }
}

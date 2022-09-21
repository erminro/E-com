using InernshipApplication.Web.Domain;
using InternshipApplication.Web.Core.Interfaces;
using InternshipApplication.Web.Core.Queries.Categories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.QueryHandler.Categories
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery,Category>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Category> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category= await _unitOfWork.CategoryRepository.Get(request.Id);
            return category;
        }
    }
}

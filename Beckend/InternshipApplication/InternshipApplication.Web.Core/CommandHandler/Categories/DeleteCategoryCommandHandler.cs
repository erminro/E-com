using InternshipApplication.Web.Core.Commands.Categories;
using InternshipApplication.Web.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.CommandHandler.Categories
{
    public class DeleteCategoryCommandHandler:IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.Get(request.Id);;
            _unitOfWork.CategoryRepository.Delete(category);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}

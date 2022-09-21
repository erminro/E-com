using AutoMapper;
using InernshipApplication.Web.Domain;
using InternshipApplication.Web.Core.Commands.Categories;
using InternshipApplication.Web.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.CommandHandler.Categories
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.Get(request.CategoryDto.Id);
            category.Name = request.CategoryDto.Name;
            var mappedRes = _mapper.Map<Category>(request.CategoryDto);
            mappedRes.Id=category.Id;
            _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}

using AutoMapper;
using InernshipApplication.Web.Domain;
using InternshipApplication.Web.Core.Commands.Categories;
using InternshipApplication.Web.Core.Dto;
using InternshipApplication.Web.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.CommandHandler.Categories
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var mappedres = _mapper.Map<Category>(request.NewCategoryDto);
            mappedres.Id = new System.Guid();
            _unitOfWork.CategoryRepository.Add(mappedres);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}

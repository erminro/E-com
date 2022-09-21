using AutoMapper;
using InernshipApplication.Web.Domain;
using InternshipApplication.Web.Core.Commands;
using InternshipApplication.Web.Core.Commands.Products;
using InternshipApplication.Web.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.CommandHandler.Products
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var mappreRes = _mapper.Map<Product>(request.NewProductDto);
            mappreRes.Id = new System.Guid();
            _unitOfWork.ProductRepository.Add(mappreRes);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}

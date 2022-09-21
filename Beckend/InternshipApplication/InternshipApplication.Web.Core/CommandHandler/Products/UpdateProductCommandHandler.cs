using AutoMapper;
using InernshipApplication.Web.Domain;
using InternshipApplication.Web.Core.Commands.Products;
using InternshipApplication.Web.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.CommandHandler.Products
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.Get(request.ProductDto.Id);
            product.Name = request.ProductDto.Name;
            product.CompanyName = request.ProductDto.CompanyName;
            product.Description = request.ProductDto.Description;
            product.Price = request.ProductDto.Price;
            product.ImagePath = request.ProductDto.ImagePath;
            var mappedRes = _mapper.Map<Product>(request.ProductDto);
            mappedRes.Id = product.Id;
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}

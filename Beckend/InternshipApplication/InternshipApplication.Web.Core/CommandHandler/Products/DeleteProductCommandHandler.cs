using InternshipApplication.Web.Core.Commands.Products;
using InternshipApplication.Web.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.CommandHandler.Products
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.Get(request.Id); ;
            _unitOfWork.ProductRepository.Delete(product);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}

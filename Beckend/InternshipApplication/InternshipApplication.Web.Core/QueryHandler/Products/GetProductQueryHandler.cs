using InernshipApplication.Web.Domain;
using InternshipApplication.Web.Core.Interfaces;
using InternshipApplication.Web.Core.Queries;
using InternshipApplication.Web.Core.Queries.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.QueryHandler.Products
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product= await _unitOfWork.ProductRepository.Get(request.Id);
            return product;
        }
    }
}

using InernshipApplication.Web.Domain;
using InternshipApplication.Web.Core.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.Commands.Products
{
    public class UpdateProductCommand : IRequest
    {
        public ProductDto ProductDto { get; set; }
    }
}

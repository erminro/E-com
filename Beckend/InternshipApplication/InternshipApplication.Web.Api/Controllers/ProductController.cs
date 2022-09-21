using InernshipApplication.Web.Domain;
using InternshipApplication.Web.Core.Commands.Products;
using InternshipApplication.Web.Core.Commands.Users;

using InternshipApplication.Web.Core.Dto;
using InternshipApplication.Web.Core.Queries.Products;
using InternshipApplication.Web.Core.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InternshipApplication.Web.Api.Controllers
{

    public class ProductController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var result = await Mediator.Send(new GetProductQuery { Id = productId });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]NewProductDto product)
        {

            var result = await Mediator.Send(new CreateProductCommand { NewProductDto = product });
            return Ok(result);
        }
        [Route("{productId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var result = await Mediator.Send(new DeleteProductCommand { Id=productId});
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto productDto)
        {
            var command = new UpdateProductCommand { ProductDto = productDto };
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
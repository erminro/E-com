using InernshipApplication.Web.Domain;
using InternshipApplication.Web.Core.Commands.Categories;
using InternshipApplication.Web.Core.Commands.Users;

using InternshipApplication.Web.Core.Dto;
using InternshipApplication.Web.Core.Queries.Categories;
using InternshipApplication.Web.Core.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InternshipApplication.Web.Api.Controllers
{

    public class CategoryController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetCategory(Guid categoryId)
        {
            var result = await Mediator.Send(new GetCategoryQuery { Id = categoryId });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] NewCategoryDto categoryDto)
        {

            var result = await Mediator.Send(new CreateCategoryCommand { NewCategoryDto = categoryDto });
            return Ok(result);
        }
        [Route("{userId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
        {
            var result = await Mediator.Send(new DeleteCategoryCommand { Id = categoryId });
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] CategoryDto categoryDto)
        {
            var command = new UpdateCategoryCommand { CategoryDto = categoryDto };
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
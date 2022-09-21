using InternshipApplication.Web.Core.Dto;
using MediatR;

namespace InternshipApplication.Web.Core.Commands.Categories
{
    public class UpdateCategoryCommand : IRequest
    {
        public CategoryDto CategoryDto { get; set; }
    }
}

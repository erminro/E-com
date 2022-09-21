using InernshipApplication.Web.Domain;
using InternshipApplication.Web.Core.Dto;
using MediatR;

namespace InternshipApplication.Web.Core.Commands.Categories
{
    public class CreateCategoryCommand : IRequest
    {
        public NewCategoryDto NewCategoryDto{ get; set; }

    }
}

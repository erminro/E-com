using InernshipApplication.Web.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.Queries.Categories
{
    public class GetCategoryQuery:IRequest<Category>
    {

       public Guid Id { get; set; }
    }
}

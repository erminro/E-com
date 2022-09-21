using InernshipApplication.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        Category Update(Category category);
        Task<Category> Get(Guid id);
        void Delete(Category category);

    }
}

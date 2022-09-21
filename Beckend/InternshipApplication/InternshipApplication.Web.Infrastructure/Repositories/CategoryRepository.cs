using InernshipApplication.Web.Domain;
using InternshipApplication.Web.Core.Interfaces.Repositories;
using InternshipApplication.Web.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _dataContext;
        public CategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Add(Category category)
        {
            _dataContext.Categories.Add(category);
        }

        public void Delete(Category category)
        {
            _dataContext.Categories.Remove(category);
        }
        public async Task<Category> Get(Guid id)
        {
            var category = await _dataContext.Categories.FirstOrDefaultAsync(category => category.Id == id);
            if (category == null)
            {
                throw new ApplicationException($"Category with id: {id} does not exist");
            }
            return category;
        }

        public Category Update(Category category)
        {
            var updatedcategory = _dataContext.Categories.FirstOrDefault(u => u.Id == category.Id);
            updatedcategory = category;
            return updatedcategory;
        }
    }
}

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
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;
        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Add(Product product)
        {
            _dataContext.Products.Add(product);
        }

        public void Delete(Product product)
        {
            _dataContext.Products.Remove(product);
        }

        public async Task<Product> Get(Guid id)
        {
            var product = await _dataContext.Products.FirstOrDefaultAsync(user => user.Id == id);
            if (product == null)
            {
                throw new ApplicationException($"User with id: {id} does not exist");
            }
            return product;
        }

        public Product Update(Product product)
        {
            var updatedproduct = _dataContext.Products.FirstOrDefault(u => u.Id == product.Id);
            updatedproduct = product;
            return updatedproduct;
        }
    }
}

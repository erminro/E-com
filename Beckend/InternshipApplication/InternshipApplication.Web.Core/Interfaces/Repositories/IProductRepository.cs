using InernshipApplication.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.Interfaces.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);

        Task<Product> Get(Guid id);

        Product Update(Product product);

        void Delete(Product product);

    }
}

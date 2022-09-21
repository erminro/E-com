using InternshipApplication.Web.Core.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; set; }
        IProductRepository ProductRepository { get; set; }
        ICategoryRepository CategoryRepository { get; set; }
        Task<int> SaveChangesAsync();     
    }
}

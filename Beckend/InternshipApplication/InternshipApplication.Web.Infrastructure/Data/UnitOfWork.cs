using InternshipApplication.Web.Core.Interfaces;
using InternshipApplication.Web.Core.Interfaces.Repositories;
using InternshipApplication.Web.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _appDbContext;
        private IUserRepository _userRepository;
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;

        public UnitOfWork(DataContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_appDbContext);
                }
                return _userRepository;
            }
            set
            {
                _userRepository = value;
            }

        }
        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_appDbContext);
                }
                return _productRepository;
            }
            set
            {
                _productRepository = value;
            }
        }
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_appDbContext);
                }
                return _categoryRepository;
            }
            set
            {
                _categoryRepository = value;
            }
        }
        public async Task<int> SaveChangesAsync()
        {

            return await _appDbContext.SaveChangesAsync();
        }

    }
}

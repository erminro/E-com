using InernshipApplication.Web.Domain;
using InternshipApplication.Web.Core.Interfaces.Repositories;
using InternshipApplication.Web.Infrastructure.Data;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Add(User user)
        {
            _dataContext.Users.Add(user);
        }

        public async Task<User> Get(Guid id)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user == null)
            {
                throw new ApplicationException($"User with id: {id} does not exist");
            }
            return user;
        }
        public void Delete(User user)
        {
            _dataContext.Users.Remove(user);
        }
        public User Update(User user)
        {
            var updateduser = _dataContext.Users.FirstOrDefault(u => u.Id == user.Id);
            updateduser = user;
            return updateduser;
        }

    }
}

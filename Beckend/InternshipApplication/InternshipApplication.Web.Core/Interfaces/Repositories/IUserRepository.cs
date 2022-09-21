using InernshipApplication.Web.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        
        void Add(User user);
        Task<User> Get(Guid id);
        void Delete(User user); 
        User Update(User user);
    }
}

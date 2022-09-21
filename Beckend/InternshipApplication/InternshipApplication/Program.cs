using InernshipApplication.Web.Domain;
using InternshipApplication.Web.Core;
using InternshipApplication.Web.Core.CommandHandler.Users;
using InternshipApplication.Web.Core.Commands;
using InternshipApplication.Web.Core.Commands.Users;
using InternshipApplication.Web.Infrastructure.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InternshipApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cancel = new CancellationToken();
            User user1 = new User { Id =Guid.NewGuid(), Name = "User2" ,Email="user2@gmail.com"};
            var dbContext = new DataContext();
            var unitOfWork = new UnitOfWork(dbContext); //Add Users 
            var createUserCommandHander = new CreateUserCommandHandler(unitOfWork);
            var userCommand = new CreateUserCommand
            {
                User = user1,
            };
              await createUserCommandHander.Handle(userCommand,cancel);
            //Get Users
            //Guid user1id = user1.Id;
           // Console.WriteLine(dbContext.Users.Count);
            //User user2=unitOfWork.UserRepository.GetUser( );
           // unitOfWork.UserRepository.DeleteUser(user1);
           // Console.WriteLine(dbContext.Users.Count);
            var test = "yes";
        }
    }
}

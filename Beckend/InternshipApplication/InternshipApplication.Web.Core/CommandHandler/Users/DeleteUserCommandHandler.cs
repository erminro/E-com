using InternshipApplication.Web.Core.Commands.Users;
using InternshipApplication.Web.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.CommandHandler.Users
{
    public class DeleteProductCommandHandler:IRequestHandler<DeleteUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.Get(request.Id);
            _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}

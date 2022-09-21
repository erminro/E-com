using AutoMapper;
using InernshipApplication.Web.Domain;
using InternshipApplication.Web.Core.Commands.Users;
using InternshipApplication.Web.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.CommandHandler.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var mappedres = _mapper.Map<User>(request.NewUserDto);
            mappedres.Id = new System.Guid();
            _unitOfWork.UserRepository.Add(mappedres);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}

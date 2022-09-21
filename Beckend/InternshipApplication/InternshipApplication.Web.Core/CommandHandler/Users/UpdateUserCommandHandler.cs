using AutoMapper;
using InernshipApplication.Web.Domain;
using InternshipApplication.Web.Core.Commands.Users;
using InternshipApplication.Web.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InternshipApplication.Web.Core.CommandHandler.Users
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.Get(request.UserDto.Id);
            user.Surname = request.UserDto.Surname;
            user.Email = request.UserDto.Email;
            user.Name = request.UserDto.Name;
            var mappedRes = _mapper.Map<User>(request.UserDto);
            mappedRes.Id = user.Id;
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}

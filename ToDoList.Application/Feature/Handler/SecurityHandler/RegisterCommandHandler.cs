using AutoMapper;
using MediatR;
using ToDiList.Domain.Model.Security;
using ToDiList.Domain.Repository;
using ToDiList.Domain.ResultModel;
using ToDoList.Application.DTO.ModelDto;
using ToDoList.Application.Feature.Command.SecurityFeatrue;

namespace ToDoList.Application.Feature.Handler.SecurityHandler
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<bool>>
    {
        private readonly IRepository<ApplicationUser> _userRepo;
        private readonly IMapper _mapper;
        public RegisterCommandHandler
            (
                IRepository<ApplicationUser> userRepo,
                IMapper mapper
            )
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public Task<Result<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationUserDto();

            ApplicationUser newUser = _mapper.Map<ApplicationUser>(dto);

            throw new NotImplementedException();
        }
    }
}

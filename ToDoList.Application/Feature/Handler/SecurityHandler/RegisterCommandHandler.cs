using AutoMapper;
using MediatR;
using ToDiList.Domain.ErrorMessage;
using ToDiList.Domain.Model.Security;
using ToDiList.Domain.Repository;
using ToDiList.Domain.ResultModel;
using ToDoList.Application.DTO.ModelDto;
using ToDoList.Application.Feature.Command.SecurityFeatrue;
using ToDoList.Identity.Utilities;

namespace ToDoList.Application.Feature.Handler.SecurityHandler
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<bool>>
    {
        private readonly IRepository<ApplicationUser> _userRepo;
        private readonly IApplicationUserRepository _specificUserRepo;
        private readonly IMapper _mapper;
        public RegisterCommandHandler
            (
                IRepository<ApplicationUser> userRepo,
                IApplicationUserRepository specificUserRepo,
                IMapper mapper
            )
        {
            _specificUserRepo = specificUserRepo;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<Result<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            bool isEmailUniqie = await _specificUserRepo.IsUnique(request.Email);
            if (!isEmailUniqie)
                return Result<bool>.Faild(SecurityErrorMessage.NoUniquieValue);


            ApplicationUser newUser = _mapper.Map<ApplicationUser>(request);

            return Result<bool>.Success(true);
        }
    }
}

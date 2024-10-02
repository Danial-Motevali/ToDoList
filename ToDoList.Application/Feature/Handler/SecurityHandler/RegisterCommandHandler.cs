using AutoMapper;
using MediatR;
using ToDiList.Domain.ErrorMessage;
using ToDiList.Domain.Model.Security;
using ToDiList.Domain.Repository;
using ToDiList.Domain.ResultModel;
using ToDoList.Application.Contract.Utilities.IdentityLayer;
using ToDoList.Application.DTO.ModelDto;
using ToDoList.Application.Feature.Command.SecurityFeatrue;

namespace ToDoList.Application.Feature.Handler.SecurityHandler
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<bool>>
    {
        private readonly IRepository<ApplicationUser> _userRepo;
        private readonly IApplicationUserRepository _specificUserRepo;
        private readonly IMapper _mapper;
        private readonly IHashPasswordHelperUtiltiy _hashPasswordHelperUtiltiy;
        public RegisterCommandHandler
            (
                IRepository<ApplicationUser> userRepo,
                IApplicationUserRepository specificUserRepo,
                IHashPasswordHelperUtiltiy hashPasswordHelperUtiltiy,
                IMapper mapper
            )
        {
            _specificUserRepo = specificUserRepo;
            _hashPasswordHelperUtiltiy = hashPasswordHelperUtiltiy;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<Result<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            bool isEmailUniqie = await _specificUserRepo.IsUnique(request.Email);
            if (!isEmailUniqie)
                return Result<bool>.Faild(SecurityErrorMessage.NoUniquieValue);

            string passwordHash = _hashPasswordHelperUtiltiy.ConverToHash(request.Password);

            ApplicationUserDto newUserDto = new ();

            newUserDto.FirstName = request.FirstName;
            newUserDto.LastName = request.LastName;
            newUserDto.UserName = request.UserName;
            newUserDto.Email = request.Email;
            newUserDto.PasswordHash = passwordHash;

            ApplicationUser newUser = _mapper.Map<ApplicationUser>(newUserDto);

            return Result<bool>.Success(true);
        }
    }
}

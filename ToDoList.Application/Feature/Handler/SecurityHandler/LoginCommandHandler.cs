using MediatR;
using ToDiList.Domain.ErrorMessage;
using ToDiList.Domain.Model.Security;
using ToDiList.Domain.Repository;
using ToDiList.Domain.ResultModel;
using ToDoList.Application.Contract.Utilities.IdentityLayer;
using ToDoList.Application.Feature.Command.SecurityFeatrue;

namespace ToDoList.Application.Feature.Handler.SecurityHandler
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<string>>
    {
        private readonly IRepository<ApplicationUser> _userRepo;
        private readonly ITokenHelperUtility _tokenHelperUtility;
        private readonly IHashPasswordHelperUtiltiy _hashPasswordHelperUtiltiy;
        public LoginCommandHandler
            (
                IRepository<ApplicationUser> userRepo,
                ITokenHelperUtility tokenHelperUtility,
                IHashPasswordHelperUtiltiy hashPasswordHelperUtiltiy
            )
        {
            _userRepo = userRepo;
            _tokenHelperUtility = tokenHelperUtility;
            _hashPasswordHelperUtiltiy = hashPasswordHelperUtiltiy;
        }

        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser? targetedUser = _userRepo.Get().Where(x => x.Email == request.Email).FirstOrDefault();
            if (targetedUser == null)
                return Result<string>.Faild(SecurityErrorMessage.CantLoginTheUser);

            bool validPassword = _hashPasswordHelperUtiltiy.ValidateTheHash(request.Password, targetedUser.PasswordHash);
            if (!validPassword)
                return Result<string>.Faild(SecurityErrorMessage.CantLoginTheUser);

            string token = _tokenHelperUtility.CreateToken(targetedUser);
            if(!String.IsNullOrEmpty(token))
                return Result<string>.Success(token);

            return Result<string>.Faild(SecurityErrorMessage.CantLoginTheUser);
        }
    }
}

using MediatR;
using ToDiList.Domain.ResultModel;
using ToDoList.Application.Feature.Command.SecurityFeatrue;

namespace ToDoList.Application.Feature.Handler.SecurityHandler
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<string>>
    {
        public Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

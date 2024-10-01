using MediatR;
using ToDiList.Domain.ResultModel;
using ToDoList.Application.Feature.Command.SecurityFeatrue;

namespace ToDoList.Application.Feature.Handler.SecurityHandler
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<bool>>
    {
        public Task<Result<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

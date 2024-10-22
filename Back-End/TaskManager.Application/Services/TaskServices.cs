using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TaskManager.Application.Dto;
using TaskManager.Application.Utilities;
using TaskManager.Domain.Contract.Repository;
using TaskManager.Domain.Contract.Services;
using TaskManager.Domain.SystemEntity;

namespace TaskManager.Application.Services
{
    public class TaskServices : ITaskService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IGenericRepository<UserTask> _userTaskRepo;
        public TaskServices
            (
                IHttpContextAccessor http,
                IGenericRepository<UserTask> userTask
            )
        {
            _httpContext = http;
            _userTaskRepo = userTask;
        }

        public ResultDto AddNewTask(AddTaskDtoInput request)
        {
            UserTask task = new();

            try
            {
                int currentUserId = _httpContext.HttpContext.GetUserId();

                task.UserId = currentUserId;
                task.Name = request.TaskName;

                (bool, UserTask) result = _userTaskRepo.Insert(task);
                if(!result.Item1)
                    return new ResultDto() { IsSuccess = false };

                return new ResultDto() { IsSuccess = true};

            }
            catch (Exception ex) 
            {
                return new ResultDto() { IsSuccess = false, ErrorMessage = "Cant Create a New Task"};
            }
        }
    }
}

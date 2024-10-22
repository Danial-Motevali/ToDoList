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
        private readonly ITaskRepository _userTaskRepo;
        public TaskServices
            (
                IHttpContextAccessor http,
                ITaskRepository userTask
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

        public ResultDto ChangeCompletion(int id)
        {
            UserTask task = _userTaskRepo.GETById(id);
            if(task == null)
                return new ResultDto() { IsSuccess = false };

            if(task.IsCompleted)
            {
                task.IsCompleted = false;
            }
            else
            {
                task.IsCompleted = true;
            }

            (bool, UserTask) result = _userTaskRepo.Update(task);
            if (result.Item1)
                return new ResultDto() { IsSuccess = true };

            return new ResultDto() {IsSuccess = false};
        }

        public async Task<ResultDto> GetALlTheTask(GetAllTaskFilter filter)
        {
            try
            {
                ResultDto result = new();
                int userId = _httpContext.HttpContext.GetUserId();

                switch (filter.SearhTerms)
                {
                    case "All":
                        result.Data = await _userTaskRepo.All(userId);
                        break;

                    case "AllAndDelete":
                        result.Data = _userTaskRepo.AllAndDelete(userId);
                        break;

                    case "CompletedOnly":
                        result.Data = _userTaskRepo.CompletedOnly(userId);
                        break;

                    case "DeletedOnly":
                        result.Data = _userTaskRepo.DeletedOnly(userId);
                        break;

                    case "InProgressOnly":
                        result.Data = _userTaskRepo.InProgressOnly(userId);
                        break;

                    default:
                        result.Data = null;
                        break;
                }

                if(result.Data == null)
                    return new ResultDto() { IsSuccess = false, ErrorMessage = "Can`t bring any Task" };

                result.IsSuccess = true;

                return result;
            }
            catch (Exception ex) 
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    ErrorMessage = "Can`t bring any Task"
                };
            }

            throw new NotImplementedException();
        }

        public ResultDto RemoveTask(int id)
        {
            UserTask targetTask = _userTaskRepo.GETById(id);
            if (targetTask == null)
                return new ResultDto() { IsSuccess = false, ErrorMessage = "NO Task Found" };

            if (targetTask.IsDeleted)
            {
                targetTask.IsDeleted = false;
            }
            else
            {
                targetTask.IsDeleted = true;
            }

            (bool, UserTask) result = _userTaskRepo.Update(targetTask);
            if (result.Item1)
                return new ResultDto() { IsSuccess = true };

            return new ResultDto() { IsSuccess = false };
        }
    }
}

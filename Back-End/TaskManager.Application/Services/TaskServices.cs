using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TaskManager.Application.Dto;
using TaskManager.Application.Utilities;
using TaskManager.Domain.Contract.Services;

namespace TaskManager.Application.Services
{
    public class TaskServices : ITaskService
    {
        private readonly IHttpContextAccessor _httpContext;
        public TaskServices(IHttpContextAccessor http)
        {
            _httpContext = http;
        }

        public ResultDto AddNewTask(AddTaskDtoInput request)
        {
            var test = _httpContext.HttpContext.GetUserId();
                //.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return new ResultDto();
        }
    }
}

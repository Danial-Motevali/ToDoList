using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Dto;
using TaskManager.Domain.Contract.Services;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaksController(ITaskService taskService)
        {
            _taskService = taskService;
        }


        [HttpPost]
        [Route("AddTask")]
        [Authorize]
        public IActionResult AddTask(AddTaskDtoInput input)
        {
            return Ok(_taskService.AddNewTask(input));
        }
    }
}

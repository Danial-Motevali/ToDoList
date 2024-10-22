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

        [HttpGet]
        [Route("AllTasks")]
        [Authorize]
        public async Task<IActionResult> GetAllTask([FromQuery] GetAllTaskFilter filter)
        {
            return Ok(await _taskService.GetALlTheTask(filter));
        }

        [HttpPost]
        [Route("DeleteOrUnDelete")]
        [Authorize]
        public IActionResult DeleteOrUnDelete([FromQuery] int id)
        {
            return Ok(_taskService.RemoveTask(id));
        }

        [HttpPost]
        [Route("ChangeCompletion")]
        [Authorize]
        public IActionResult ChangeCompletion([FromQuery] int id)
        {
            return Ok(_taskService.ChangeCompletion(id));
        }
    }
}

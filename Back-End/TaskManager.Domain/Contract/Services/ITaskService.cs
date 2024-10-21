using TaskManager.Application.Dto;

namespace TaskManager.Domain.Contract.Services
{
    public interface ITaskService
    {
        ResultDto AddNewTask(AddTaskDtoInput request);
    }
}

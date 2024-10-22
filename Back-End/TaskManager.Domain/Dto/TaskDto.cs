namespace TaskManager.Application.Dto
{
    public class AddTaskDtoInput
    {
        public string TaskName { get; set; }
    }

    public class GetAllTaskFilter
    {
        public string SearhTerms { get; set; }
    }
}

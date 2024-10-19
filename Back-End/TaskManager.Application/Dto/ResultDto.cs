namespace TaskManager.Application.Dto
{
    public class ResultDto
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
    }
}

namespace ToDiList.Domain.ResultModel
{
    public class Result<T>
    {
        public bool IsSucces { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }

        public static Result<T> Success(T data) => new Result<T> { IsSucces = true, Data = data };
        public static Result<T> Faild(string message) => new Result<T> { IsSucces = false, ErrorMessage = message };

    }
}

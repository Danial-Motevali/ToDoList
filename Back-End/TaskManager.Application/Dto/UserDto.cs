namespace TaskManager.Application.Dto
{
    public class UserSignUpDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserSignInDto 
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

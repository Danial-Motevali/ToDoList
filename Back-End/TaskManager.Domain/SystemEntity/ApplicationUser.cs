namespace TaskManager.Domain.SystemEntity
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public virtual List<UserTask>? Tasks { get; set; }
    }
}

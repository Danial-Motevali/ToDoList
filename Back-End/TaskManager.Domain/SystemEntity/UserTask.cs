namespace TaskManager.Domain.SystemEntity
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsCompleted { get; set; } = false;
        public DateTime Created { get; set; } = DateTime.Now;
        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}

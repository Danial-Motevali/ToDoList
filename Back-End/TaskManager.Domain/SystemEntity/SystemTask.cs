namespace TaskManager.Domain.SystemEntity
{
    public class SystemTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}

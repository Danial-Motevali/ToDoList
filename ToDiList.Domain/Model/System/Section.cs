using ToDiList.Domain.Model.Base;
using ToDiList.Domain.Model.Security;

namespace ToDiList.Domain.Model.System
{
    public class Section : BaseModel<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}

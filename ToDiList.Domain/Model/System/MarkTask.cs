using ToDiList.Domain.Model.Base;

namespace ToDiList.Domain.Model.System
{
    public class MarkTask : BaseModel<int>
    {
        public string Name { get; set; }
        public virtual ICollection<Task>? Tasks { get; set; }
    }
}

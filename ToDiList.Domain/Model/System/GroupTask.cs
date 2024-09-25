using ToDiList.Domain.Model.Base;

namespace ToDiList.Domain.Model.System
{
    public class GroupTask : BaseModel<int>
    {
        public string Name { get; set; }
        public virtual ICollection<ApplicationTask>? Tasks { get; set; }


        public GroupTask
            (
                string Name            
            )
        {
            this.Name = Name;
        }
    }
}

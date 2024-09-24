using ToDiList.Domain.Model.Base;

namespace ToDiList.Domain.Model.System
{
    public class Task : BaseModel<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DoDate { get; set; }
        public bool IsCompeleted { get; set; } = false;
        public int SectionId { get; set; }
        public int? ParentId { get; set; }

        public virtual Task? Steps { get; set; }
        public virtual Section Section { get; set; }
    }
}

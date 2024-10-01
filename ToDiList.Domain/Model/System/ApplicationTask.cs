using ToDiList.Domain.Model.Base;

namespace ToDiList.Domain.Model.System
{
    public class ApplicationTask : BaseModel<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DoDate { get; set; }
        public bool IsCompeleted { get; set; } 
        public int SectionId { get; set; }
        public int? ParentId { get; set; }
        public int? GroupTaskId { get; set; }

        public virtual ApplicationTask? Steps { get; set; }
        public virtual Section Section { get; set; }
        public virtual GroupTask GroupTask { get; set; }

        public ApplicationTask()
        {
        }

        public ApplicationTask
            (
                string Name,
                string? Description,
                DateTime? DoDate,
                bool? IsCompeleted,
                int SectionId,
                int? ParentId,
                int? GroupTaskId
            )
        {
            this.Name = Name;
            this.Description = Description != null ? Description : string.Empty;
            this.DoDate = DoDate != null ? DoDate : null;
            this.IsCompeleted = IsCompeleted != null ? (bool)IsCompeleted : false;
            this.SectionId = SectionId;
            this.ParentId = ParentId != null ? ParentId : null;
            this.GroupTaskId = GroupTaskId != null ? GroupTaskId : null;
        }
    }
}

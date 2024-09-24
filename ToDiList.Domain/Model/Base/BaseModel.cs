namespace ToDiList.Domain.Model.Base
{
    public abstract class BaseModel<TKey> : IBaseModel<TKey>
    {
        public TKey Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime InsertDate { get; set; } = DateTime.Now;
    }
}

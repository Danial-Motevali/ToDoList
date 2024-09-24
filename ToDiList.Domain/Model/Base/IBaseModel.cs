namespace ToDiList.Domain.Model.Base
{
    public interface IBaseModel<TKey>
    {
        TKey Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime InsertDate { get; set; }

    }
}

namespace TaskManager.Domain.Contract.Repository
{
    public interface IGenericRepository<TEntity>
    {
        TEntity GETById(object Id);
        List<TEntity> GetAll();
        (bool, TEntity) Insert(TEntity data);
        (bool, TEntity) Update(TEntity data);
        bool Remove(TEntity entity);
    }
}

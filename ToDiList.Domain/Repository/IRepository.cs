using System.Linq.Expressions;

namespace ToDiList.Domain.Repository
{
    public interface IRepository<T>
    {
        T GetById(object id);
        List<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy=null, string incluses = "");
        void Delete(T entity);
        void DeleteById(object id);
        void Update(T entity);
        void Insert(T entity);
    }
}

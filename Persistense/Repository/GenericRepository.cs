using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDiList.Domain.Repository;
using ToDoList.Persistense.DATA;

namespace ToDoList.Persistense.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ApplicationDbContext _context;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached) 
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public void DeleteById(object id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string incluses = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if(where != null)
                query = query.Where(where);

            if (orderBy != null)
                query = orderBy(query);

            if (!String.IsNullOrEmpty(incluses))
            {
                foreach(string turn in incluses.Split(','))
                {
                    query = query.Include(turn);
                }
            }

            return query.ToList();
        }

        public List<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Entry(entity).State = EntityState.Modified;
        }
    }
}

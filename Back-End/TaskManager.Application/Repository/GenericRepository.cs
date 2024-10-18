using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Data;
using TaskManager.Domain.Contract.Repository;

namespace TaskManager.Application.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<TEntity> _dbSet; 

        public List<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GETById(object Id)
        {
            return _dbSet.Find(Id);
        }

        public (bool, TEntity) Insert(TEntity data)
        {
            _context.Add(data);
            int result = _context.SaveChanges();

            if(result != 0)
            {
                return (true, data);
            }

            return (false, data);
        }

        public bool Remove(TEntity entity)
        {
            _context.Remove(entity);
            int result = _context.SaveChanges();

            if (result != 0)
                return true;

            return false;
        }

        public (bool, TEntity) Update(TEntity data)
        {
            _dbSet.Attach(data);
            _context.Entry(data).State = EntityState.Modified;

            int result = _context.SaveChanges();

            if (result != 0)
                return (true, data);

            return (false, data);
        }
    }
}

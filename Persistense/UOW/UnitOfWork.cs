using ToDiList.Domain.UOW;
using ToDoList.Persistense.DATA;

namespace ToDoList.Persistense.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CompleteAsynce(CancellationToken cancellationToken)
        {
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

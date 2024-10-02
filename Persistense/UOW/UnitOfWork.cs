using ToDiList.Domain.UOW;
using ToDoList.Persistense.DATA;

namespace ToDoList.Persistense.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed = false; // To detect redundant calls
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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources  
                    _context?.Dispose();
                }

                // Dispose unmanaged resources here (if any)  

                _disposed = true;
            }
        }
    }
}

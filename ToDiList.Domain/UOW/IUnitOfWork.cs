namespace ToDiList.Domain.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CompleteAsynce(CancellationToken cancellationToken);
    }
}

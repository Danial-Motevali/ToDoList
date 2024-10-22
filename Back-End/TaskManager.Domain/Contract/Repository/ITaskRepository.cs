using TaskManager.Domain.SystemEntity;

namespace TaskManager.Domain.Contract.Repository
{
    public interface ITaskRepository : IGenericRepository<UserTask>
    {
        Task<List<UserTask>> All(int Id);
        Task<List<UserTask>> AllAndDelete(int Id);
        Task<List<UserTask>> CompletedOnly(int Id);
        Task<List<UserTask>> DeletedOnly(int Id);
        Task<List<UserTask>> InProgressOnly(int Id);
    }
}

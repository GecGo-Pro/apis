using apis.Models;

namespace apis.IRepository
{
    public interface IDispatchJobRepo
    {
        Task<IEnumerable<DispatchJob>> Get();
        Task<DispatchJob> Get(int id);
        // Task<DispatchJob> Create(DispatchJobDTO dispatchJobDto);
        // Task<DispatchJob> Put(int id, DispatchJobDTO dispatchJobDto);
        // Task<DispatchJob> Delete(int id);
    }
}

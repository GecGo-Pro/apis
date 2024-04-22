using apis.Models;

namespace apis.IRepository
{
    public interface IDispatcherRepo
    {
        Task<IEnumerable<Dispatcher>> Get();
        Task<Dispatcher> Get(int id);
        Task<Dispatcher> Create(DispatcherDTO dispatcher);
        Task<Dispatcher> Put(int id, DispatcherDTO dispatcher);
        Task<Dispatcher> Delete(int id);
    }
}

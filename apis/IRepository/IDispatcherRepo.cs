using apis.Models;

namespace apis.IRepository
{
    public interface IDispatcherRepo
    {
        Task<IEnumerable<Dispatcher>> Get();
        Task<Dispatcher> Get(int id);
        Task<Dispatcher> Create(Dispatcher dispatcher);
        Task<Dispatcher> Put(int id, Dispatcher dispatcher);
        Task<Dispatcher> Delete(int id);
    }
}

using apis.Models;

namespace apis.IRepository
{
    public interface IDriverRepo
    {
        Task<IEnumerable<Driver>> Get();
        Task<Driver> Get(int id);
        Task<Driver> Create(Driver driver);
        Task<Driver> Put(int id, Driver drive);
        Task<Driver> Delete(int id);
    }
}

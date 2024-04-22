using apis.Models;

namespace apis.IRepository
{
    public interface IDriverRepo
    {
        Task<IEnumerable<Driver>> Get();
        Task<Driver> Get(int id);
        Task<Driver> Create(DriverDTO driverDTO);
        Task<Driver> Put(int id, DriverDTO driverDTO);
        Task<Driver> Delete(int id);
    }
}

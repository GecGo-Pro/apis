using apis.Models;

namespace apis.IRepository
{
    public interface ITokenRepo
    {
        string TokenCustomer(Customer customer);
        string TokenDispatcher(Dispatcher dispatcher);
    }
}

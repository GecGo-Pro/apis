using apis.Models;

namespace apis.IRepository
{
    public interface IAuthRepo
    {
        string TokenCustomer(Customer result_otp);
    }
}

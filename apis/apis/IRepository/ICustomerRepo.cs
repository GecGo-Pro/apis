using apis.Models;

namespace apis.IRepository
{
    public interface ICustomerRepo
    {
        Task<bool> CheckExist(string phone);
        Task<Customer> CheckOTP(string phone,string otp);
        Task<string> CreateOTP(string phone); 
    }
}
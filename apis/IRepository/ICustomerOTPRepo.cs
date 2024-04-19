using apis.Models;

namespace apis.IRepository
{
    public interface ICustomerOTPRepo
    {
        Task<Customer> CheckExist(string phone);
        Task<string> VeryfyOTP(string phone,string otp);
        Task<string?> CreateOTP(string phone);
    }
}
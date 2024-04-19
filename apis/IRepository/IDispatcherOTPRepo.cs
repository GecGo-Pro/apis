using apis.Models;

namespace apis.IRepository
{
    public interface IDispatcherOTPRepo
    {
        Task<Dispatcher> CheckExist(string phone);
        Task<string> VeryfyOTP(string phone,string otp);
        Task<string?> CreateOTP(string phone);
    }
}
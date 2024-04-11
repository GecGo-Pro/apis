using apis.IRepository;
using apis.Models;
using apis.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Twilio.Clients;

namespace apis.Services
{
    public partial class CustomerService : ICustomerRepo
    {
        private readonly DatabaseContext _db;
        private readonly IConfiguration _configuration;
        private readonly ITwilioRestClient _client;
        private readonly IAuthRepo _authRepo;

        public CustomerService(DatabaseContext db, IConfiguration configuration, ITwilioRestClient client, IAuthRepo authRepo)
        {
            _db = db;
            _configuration = configuration;
            _client = client;
            _authRepo = authRepo;
        }

        public async Task<Customer> CheckExist(string phone)
        {
            var existingCustomer = await _db.customers.FirstOrDefaultAsync(x=>x.phone_number==phone);
            if (existingCustomer != null)
            {
                    return existingCustomer;
            }
            throw new HtttpException(404, "Phone Fail!!", "Phone Not Existing in Database. Please register for an account using your phone number ");
        }


        public async Task<string?> CreateOTP(string phone)
        {
            if (MyRegex.RegexPhone().IsMatch(phone))
            {
                Customer existingCustomer = await CheckExist(phone);
                    if ( DateTime.Compare(existingCustomer.otp_life, DateTime.UtcNow) < 0)
                    {
                        var random = new Random();
                        string OTP = new(Enumerable.Repeat("0123456789", 6).Select(s => s[random.Next(s.Length)]).ToArray());
                        using (IDbContextTransaction transaction = _db.Database.BeginTransaction())
                        {
                            existingCustomer.otp = int.Parse(OTP);
                            existingCustomer.otp_life = DateTime.UtcNow.AddMinutes(2);
                            await _db.SaveChangesAsync();
                            if (_configuration["ASPNETCORE_ENVIRONMENT"] == "Production")
                            {
                                //environment Pro
                                SendSms s = new();
                                try
                                {
                                    s.Send(phone, OTP, _client);
                                    transaction.Commit();
                                    return null;
                                }
                                catch (Exception)
                                {
                                    transaction.Rollback();
                                    throw new HtttpException(500, "Send OTP Fail!!", "Error from Server (The error may be due to OTP not being sent).");
                                }
                            }
                            else
                            {
                            //environment Dev
                            transaction.Commit();
                            return "OTP:" + OTP;
                            }
                        }
                     
                    }
                    else{   throw new HtttpException(400, "OTP Fail!!", "The current OTP is still valid. Please Retry after 2 minutes.");} 
            }
            else { throw new HtttpException(400,"Phone Fail!!", "Invalid phone number. Please enter a phone number that contains only digits, starts with 0, and has a length from 9 to 11 characters."); }
        }

        public async Task<string> VeryfyOTP(string phone, string OTP)
        {
            if (MyRegex.RegexPhone().IsMatch(phone) && MyRegex.RegexOTP().IsMatch(OTP))
            {
                Customer existingCustomer = await CheckExist(phone);
                    if (DateTime.Compare(existingCustomer.otp_life, DateTime.UtcNow) > 0)
                    {
                        if (existingCustomer.otp == int.Parse(OTP))
                        {
                            return _authRepo.TokenCustomer(existingCustomer);
                        }
                        else { throw new HtttpException(401,"OTP Fail!!","The OTP you entered is incorrect."); }
                    }
                    else { throw new HtttpException(403, "OTP Fail!!", "OTP Expired, Please choose to resend OTP."); }
            }
            else {throw new HtttpException(400,"Phone or OTP Fail!!", "Invalid phone number or OTP. Please enter a phone number that contains only digits, starts with 0, and has a length from 9 to 11 characters. OTP must be numeric and 6 characters long"); }
        }

        
    }
}

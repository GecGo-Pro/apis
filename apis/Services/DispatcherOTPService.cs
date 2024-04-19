using apis.IRepository;
using apis.Models;
using apis.Utils;
using Microsoft.EntityFrameworkCore;
using Twilio.Clients;

namespace apis.Services
{
    public class DispatcherOTPService : IDispatcherOTPRepo
    {
        private readonly DatabaseContext _db;
        private readonly IConfiguration _configuration;
        private readonly ITwilioRestClient _client;
        private readonly ITokenRepo _authRepo;

        public DispatcherOTPService(DatabaseContext db, IConfiguration configuration, ITwilioRestClient client, ITokenRepo authRepo)
        {
            _db = db;
            _configuration = configuration;
            _client = client;
            _authRepo = authRepo;
        }

        public async Task<Dispatcher> CheckExist(string phone)
        {
            var existing = await _db.dispatchers.FirstOrDefaultAsync(x => x.phone_number == phone);
            if (existing != null)
            {
                return existing;
            }
            throw new HttpException(404,Variable.NoData);
        }


        public async Task<string?> CreateOTP(string phone)
        {
            bool checkPhone = !MyRegex.RegexPhone().IsMatch(phone);
            if (checkPhone)
            {
                throw new HttpException(400, Variable.PhoneInValid);
            }
            Dispatcher existingDispatcher = await CheckExist(phone);
            bool checkOTPExpired = DateTime.Compare(existingDispatcher.otp_life, DateTime.UtcNow) > 0;
            if (checkOTPExpired)
            {
                throw new HttpException(400, Variable.OTPNotExpired);
            }
            string OTP = MyRandom.OTP();
            existingDispatcher.otp = int.Parse(OTP);
            if (_configuration["ASPNETCORE_ENVIRONMENT"] == "Production")
            {

                existingDispatcher.otp_life = DateTime.UtcNow.AddMinutes(1);
                await _db.SaveChangesAsync();
                //environment Pro
                SendSms sms = new();
                try
                {
                    sms.Send(phone, OTP, _client);
                    return null;
                }
                catch
                {
                    throw new HttpException(500, Variable.SendOTPError);
                }
            }
            existingDispatcher.otp_life = DateTime.UtcNow.AddSeconds(30);
            await _db.SaveChangesAsync();
            return "OTP:" + OTP;

        }

        public async Task<string> VeryfyOTP(string phone, string OTP)
        {
            bool checkInputValid = !MyRegex.RegexPhone().IsMatch(phone) && MyRegex.RegexOTP().IsMatch(OTP);
            if (checkInputValid)
            {
                throw new HttpException(400, Variable.PhoneInValid);
            }
            Dispatcher existingDispatcher = await CheckExist(phone);
            if (DateTime.Compare(existingDispatcher.otp_life, DateTime.UtcNow) < 0)
            {
                throw new HttpException(401, Variable.OTPExpired);
            }
            if (existingDispatcher.otp != int.Parse(OTP))
            {
                throw new HttpException(401, Variable.OTPInCorrect);
            }
            try
            {
                return _authRepo.TokenDispatcher(existingDispatcher);
            }
            catch { throw new HttpException(500, Variable.TokenError); }
        }
    }
}

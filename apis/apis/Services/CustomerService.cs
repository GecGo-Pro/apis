using apis.IRepository;
using apis.Models;
using Microsoft.EntityFrameworkCore;

namespace apis.Services
{
    public class CustomerService: ICustomerRepo
    {
        private readonly DatabaseContext db;

        public CustomerService(DatabaseContext db)
        {
            this.db = db;
        }
        public async Task<bool> CheckExist(string phone)
        {
            var existing_customer = await db.customers.Where(c => c.phone_number == phone).FirstOrDefaultAsync();
            if (existing_customer != null)
            {
                    return true;
            }
            return false;
        }


        public async Task<string> CreateOTP(string phone)
        {
            var existing_customer = await db.customers.Where(c=>c.phone_number == phone).FirstOrDefaultAsync();
            if (existing_customer!=null && DateTime.Compare(existing_customer.otp_life, DateTime.UtcNow) < 0)
            {
                const string chars = "0123456789";
                var random = new Random();
                string OTP= new string(Enumerable.Repeat(chars, 6) .Select(s => s[random.Next(s.Length)]).ToArray());

                existing_customer.otp = int.Parse(OTP);
                existing_customer.otp_life = DateTime.UtcNow.AddSeconds(30);
                int Result = await db.SaveChangesAsync();
                if (Result > 0)
                {
                    return OTP;
                }
            }
            return null;
        }

        public async Task<Customer> CheckOTP(string phone, string otp)
        {
            var existing_customer = await db.customers.Where(c => c.phone_number == phone).FirstOrDefaultAsync();
            if (existing_customer != null)
            {
                if(existing_customer.otp == int.Parse( otp))
                {
                    return existing_customer;
                }
            }
            return null;
        }
    }
}

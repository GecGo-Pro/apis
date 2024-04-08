using apis.IRepository;
using apis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace apis.Services
{
    public class CustomerService: ICustomerRepo
    {
        private readonly DatabaseContext db;
        private readonly IConfiguration config;

        public CustomerService(DatabaseContext db, IConfiguration config)
        {
            this.db = db;
            this.config = config;
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
                existing_customer.otp_life = DateTime.UtcNow.AddMinutes(2);
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

        public string TokenCustomer(Customer customer)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("phone_number",customer.phone_number),
                new Claim("name",customer.name),
                new Claim(ClaimTypes.Role,"User")
            };
            var token = new JwtSecurityToken(config["Jwt:Issuer"], config["Jwt:Audience"], claims, expires: DateTime.Now.AddDays(1), signingCredentials: credential);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

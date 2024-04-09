using apis.IRepository;
using apis.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace apis.Services
{
    public class AuthService: IAuthRepo
    {

        private readonly IConfiguration config;

        public AuthService(IConfiguration config)
        {
            this.config = config;
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

using apis.IRepository;
using apis.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace apis.Services
{
    public class TokenService : ITokenRepo
    {

        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            this._config = config;
        }

        string TokenCustomer(dynamic claims)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims, expires: DateTime.Now.AddDays(1), signingCredentials: credential);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string TokenCustomer(Customer customer)
        {
            var claims = new[]
            {
                new Claim("phone_number",customer.name),
                new Claim("name",customer.name),
                new Claim(ClaimTypes.Role,"Customer")
            };
            return TokenCustomer(claims);
        }
        public string TokenDispatcher(Dispatcher dispatcher)
        {
            var claims = new[]
            {
                new Claim("phone_number",dispatcher.phone_number),
                new Claim("name",dispatcher.name),
                new Claim(ClaimTypes.Role,"Dispatcher")
            };
            return TokenCustomer(claims);
        }

    }
}

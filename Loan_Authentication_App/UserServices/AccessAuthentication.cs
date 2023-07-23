using Loan_Authentication_App.DBContext;
using Loan_Authentication_App.IServices;
using Loan_Authentication_App.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Loan_Authentication_App.Services
{
    public class AccessAuthentication : IAuthentication
    {
        private readonly UserDB userdb;
        private readonly IConfiguration configuration;

        public AccessAuthentication(UserDB _user, IConfiguration iConfig)
        {
            this.userdb = _user;
            this.configuration = iConfig;
        }

        public async Task<string> CreateJWTToken(LoginModel loginMode)
        {

            var user = userdb.User.SingleOrDefault(x => x.UserName == loginMode.UserName && x.Password == loginMode.Password);
            var jwtToken = configuration.GetSection("Jwt").GetSection("Token").Value;

            if (user != null)
            {

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] 
                    {        
                new Claim("UserName", user.UserName.ToString()),
                new Claim("Role",user.Type.ToString())
            }),

            Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtToken)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

               
                return token;
            }
            else
            {
                throw new Exception("Invalide UserName And Password");
            }
           
        }







    }
}

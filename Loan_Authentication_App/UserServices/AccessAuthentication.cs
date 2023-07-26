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
        public IConfiguration _configuration;
        private readonly UserDB userdb;
        private readonly IConfiguration configuration;

        public AccessAuthentication(UserDB _user, IConfiguration iConfig)
        {
            this.userdb = _user;
            this.configuration = iConfig;
        }

        //public async Task<string> CreateJWTToken(LoginModel loginMode)
        //{
        //    string jwt = "Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs03Hdx";
        //    var user = userdb.User.SingleOrDefault(x => x.UserName == loginMode.UserName && x.Password == loginMode.Password);
        //   // var jwttoken = configuration.getsection("jwt").getsection("token").value;

        //    //if (user != null)
        //    //{

        //    //    //    var tokendescriptor = new securitytokendescriptor
        //    //    //    {


        //    //    //        subject = new claimsidentity(new claim[] 
        //    //    //        {        
        //    //    //    new claim("name", user.username.tostring()),
        //    //    //    new claim("role",user.type.tostring())
        //    //    //}),

        //    //    var token = new jwtsecuritytoken(
        //    //           _configuration["jwt:issuer"],
        //    //           _configuration["jwt:audience"],

        //    //           expires: datetime.utcnow.addminutes(10),
        //    //           signingcredentials: signin);

        //    //    expires = datetime.utcnow.adddays(1),
        //    //        signingcredentials = new signingcredentials(new symmetricsecuritykey(encoding.utf8.getbytes(jwttoken)), securityalgorithms.hmacsha256signature)
        //    //    };
        //    //    var tokenhandler = new jwtsecuritytokenhandler();
        //    //    var securitytoken = tokenhandler.createtoken(tokendescriptor);
        //    //    var token = tokenhandler.writetoken(securitytoken);               
        //    //    return token;
        //    //}
        //    //else
        //    //{
        //    //    throw new exception("invalide username and password");
        //    //}

        //    //if (user != null && user.UserName != null && user.Password != null)
        //    //{
        //    //    //var user = await GetUser(_userData.Email, _userData.Password);

        //    //    if (user != null)
        //    //    {
        //    //        //create claims details based on the user information
        //    //        var claims = new[] {
        //    //          //  new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
        //    //           // new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //    //           // new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),                       
        //    //            new Claim("userName", user.UserName),
        //    //           new Claim("role",user.Type.ToString())
        //    //        };

        //    //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt));
        //    //        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //    //        var token = new JwtSecurityToken(

        //    //            //_configuration["Jwt:Issuer"],
        //    //            //_configuration["Jwt:Audience"],

        //    //            expires: DateTime.UtcNow.AddMinutes(10),
        //    //            signingCredentials: signIn);

        //    //        return (new JwtSecurityTokenHandler().WriteToken(token));
        //    //    }
        //    //    else
        //    //    {
        //    //        return ("Invalid credentials");
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    return ("Invalid credentials");
        //    //}

        //}

        public async Task<string> CreateJWTToken(LoginModel loginMode)
        {
            string issuer = "Issuer";
            string Audience = "Audience";
            string jwt = "Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs03Hdx";
            var user = userdb.User.SingleOrDefault(x => x.UserName == loginMode.UserName && x.Password == loginMode.Password);
            if (user != null)
            {
                
                var key = Encoding.ASCII.GetBytes(jwt);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                new Claim("Role", "Admin"),               
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),
             }),
                    Expires = DateTime.UtcNow.AddMinutes(50),
                    Issuer = issuer,
                    Audience = Audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var stringToken = tokenHandler.WriteToken(token);
                return (stringToken);
            }
            return "Invalid user";
        }

    }
}
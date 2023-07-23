using Loan_Authentication_App.IServices;
using Loan_Authentication_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loan_Authentication_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenicationController : ControllerBase 
    {
        private readonly IAuthentication authentication;
        public AuthenicationController(IAuthentication _authentication)
        {
            this.authentication = _authentication;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult>Login([FromBody] LoginModel loginModel)
        {
            var token = await this.authentication.CreateJWTToken(loginModel);

            if (token == null || token == String.Empty)
                return BadRequest(new { message = "User name or password is incorrect" });

            return Ok(token);
        }
    }
}

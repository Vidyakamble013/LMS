using Loan_Authentication_App.Models;

namespace Loan_Authentication_App.IServices
{
    public interface IAuthentication
    {

       Task<string> CreateJWTToken(LoginModel loginMode);
    }
}

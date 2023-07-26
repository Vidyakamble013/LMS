using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        //[HttpPost("AddLoan")]
        //public async Task<ActionResult<LoanModel>> AddLoan(LoanModel loanModel)
        //{
        //    this._loan.AddLoan(loanModel);
        //    return await Task.FromResult(loanModel);
        //}
    }
}

using LMS_App.LoanInterface;
using LMS_App.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace LMS_App.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
   
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loan;
        private readonly ILoggerManager _logger;

        public LoanController(ILoanService loan, ILoggerManager logger)
        {
            this._loan = loan;
            this._logger = logger;
        }

        [HttpPost]
        [Route("addLoan")]
        public async Task<ActionResult<LoanModel>> AddLoan(LoanModel loanModel)
        {
            this._loan.AddLoan(loanModel);
            return await Task.FromResult(loanModel);
        }

        [HttpPut("updateLoanDetails")]
        //[Route("{id}")]
        public async Task<ActionResult<LoanModel>> UpdateLoanDetails( LoanModel loanModel)
        {

            try
            {
                await this._loan.UpdateLoanDetails( loanModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return await Task.FromResult(loanModel);

        }
        [HttpGet("GetLoanDetails")]

        public async Task<ActionResult> GetLoanDetails()
        {
            try
            {
                IList<LoanModel> loanModels = new List<LoanModel>();
                _logger.LogInfo("Here is info message from the controller.");
                 loanModels =  await Task.FromResult(_loan.GetLoanDetails());
                if (loanModels == null)
                {
                    return this.NotFound();
                }
                else
                {
                    return this.Ok(new { loanModels });
                }               
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("{loanId}")]
        public async Task<ActionResult<List<LoanModel>>> GetLoanDetailsByLoanId(int loanId)
        {
            try
            {
                return await Task.FromResult(_loan.GetLoanDetailsByLoanId(loanId));
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("searchloans")]
        public async Task<ActionResult<List<LoanModel>>> SearchloanDetails(SearchModel search)
        {
            try
            {
                return await Task.FromResult(_loan.SearchloanDetails(search));
            }
            catch
            {
                throw;
            }
        }

    }
}

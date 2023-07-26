using LMS_App.Model;

namespace LMS_App.LoanInterface
{
    public interface ILoanService
    {
        void AddLoan(Model.LoanModel loanModel);

        Task<bool> UpdateLoanDetails( LoanModel loanModel);

        IList<LoanModel> GetLoanDetails();
        List<LoanModel> GetLoanDetailsByLoanId(int LoanId);

        List<LoanModel> SearchloanDetails(SearchModel search);
    }
}

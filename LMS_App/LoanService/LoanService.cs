using LMS_App.LMSDBContext;
using LMS_App.LoanInterface;
using LMS_App.Model;
using Loan_Authentication_App.DBContext;
using Microsoft.EntityFrameworkCore;
using ServiceStack;
using ServiceStack.Redis;
using ServiceStack.Script;
using ServiceStack.Text;
using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace LMS_App.LoanService
{
    public class LoanService : ILoanService
    {

        private readonly LMSContext _lmsContext;
       // private readonly UserDB userdb;

        public LoanService(LMSContext lmsContext) 
        {
            this._lmsContext = lmsContext;
           // this.userdb = userdb;
           
        }
        public void  AddLoan(LoanModel loanModel) 
        {
            try
            {

                this._lmsContext.LoanDetails.Add(loanModel);
                _lmsContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateLoanDetails( LoanModel loanModel)
        {

            var result = _lmsContext.LoanDetails.Where(x => x.LoanId == loanModel.LoanId).SingleOrDefault();
            if (result != null)
            {

                result.LoanId = loanModel.LoanId;
                result.LoanNumber = loanModel.LoanNumber;
                result.LoanAmount = loanModel.LoanAmount;
                result.LoanTerms = loanModel.LoanTerms;
                result.LoanFees = loanModel.LoanFees;
                result.LegalDocument = loanModel.LegalDocument;
                result.LineInformation = loanModel.LineInformation;
                result.PropertyInformation = loanModel.PropertyInformation;
                result.BorrowerInformation = loanModel.BorrowerInformation;
                result.Status = loanModel.Status;
                result.OriginationAccount = loanModel.OriginationAccount;
                result.OriginationDate = loanModel.OriginationDate;

            }
            
            else
            {
                throw new Exception("Invalide Id ");
            }
            _lmsContext.Entry(result).State = EntityState.Modified;
            int upadte =  _lmsContext.SaveChanges();
            if(upadte > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
 
            }
        public IList<LoanModel> GetLoanDetails()
        {
            var loanList = new List<LoanModel>();
            try
            {
                var result =  _lmsContext.LoanDetails.ToList();
                foreach (var list in result)
                {
                    loanList.Add(list);
                }
            }
            catch
            {
                throw;
            }
            return loanList;
        }

        public List<LoanModel> GetLoanDetailsByLoanId(int loanId)
        {
            var loanList = new List<LoanModel>();
            try
            {
                var result = this._lmsContext.LoanDetails.Where(x => x.LoanId == loanId).ToList();
                foreach(var item in result)
                {
                    loanList.Add(item);
                }
                return loanList;
            }
            catch
            {
                throw;
            }
        }


        public List<LoanModel> SearchloanDetails(SearchModel search)
        {

            var users = new List<LoanModel>();
            var result = (from user in this._lmsContext.User
                          join loan in this._lmsContext.LoanDetails
                          on user.Id equals loan.UserId
                          where user.Firstname.StartsWith(search.Firstname) || user.LastName.StartsWith(search.Lastname ) || loan.LoanNumber.Equals(search.LoanNumber)

                          select new
                          {
                              loan.LoanNumber,
                              loan.LoanAmount,
                              loan.LoanTerms,
                              loan.LoanFees,
                              loan.LoanId,
                              loan.PropertyInformation,
                              loan.BorrowerInformation,
                              loan.LegalDocument,
                              loan.LineInformation,
                              loan.UserId,
                              loan.OriginationAccount,
                              loan.OriginationDate,
                              user.Firstname,
                              user.LastName
                          }).ToList();

            foreach (var item in result) {
           // this.users.Add(item);
            }


            return users.ToList();
        }

    }
}

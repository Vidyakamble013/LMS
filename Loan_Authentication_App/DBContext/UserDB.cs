using Loan_Authentication_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Loan_Authentication_App.DBContext
{
    public class UserDB : DbContext
    {
        public UserDB(DbContextOptions<UserDB> options) : base(options)
        {
           
        }

        public  DbSet<UserModel> User { get; set; }

        DbSet<LoanModel> LoanDetails { get; set; }

    }

}

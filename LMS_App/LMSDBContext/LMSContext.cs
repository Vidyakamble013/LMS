using LMS_App.Model;
using Microsoft.EntityFrameworkCore;

namespace LMS_App.LMSDBContext
{
    public class LMSContext: DbContext
    {
        public LMSContext(DbContextOptions<LMSContext> options): base(options)
        {

        }
        public DbSet<LoanModel> LoanDetails { get; set; }
        public DbSet<UserModel> User { get; set; }

    }
}

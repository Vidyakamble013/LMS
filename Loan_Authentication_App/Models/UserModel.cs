using System.ComponentModel.DataAnnotations;

namespace Loan_Authentication_App.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string LastName { get; set; }
       
        public string Address { get; set; }
        
        public string UserName { get; set; }
        
        public string Password { get; set; }

        public int Type { get; set; }

        public ICollection<LoanModel> loanModels { get; set; }
    }
}

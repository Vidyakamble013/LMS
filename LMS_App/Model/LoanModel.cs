using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS_App.Model
{
    public class LoanModel
    {
        [Key]
        [Required]
        public int LoanId { get; set; }
        [Required]
        public int LoanNumber { get; set; }
        public double? LoanAmount { get; set; }
        public int? LoanTerms { get; set; }
        public string? BorrowerInformation { get; set; }
        [Required]
        public string PropertyInformation { get; set; }
        public string? Status { get; set; }
        public double? LoanFees { get; set; }

        public DateTime OriginationDate { get; set; }

        public string? OriginationAccount { get; set; }
        public string? LineInformation { get; set; }
        public string? LegalDocument { get; set; }
        [ForeignKey("UserModel")]
        [Required]
        public int UserId { get; set; }

       
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebAppSample.Models
{
    public class Institution
    {
        [ScaffoldColumn(false)]
        public int InstitutionID { get; set; }
        [Required]
        public string Name { get; set; }
        

        [ScaffoldColumn(false)]
        public int ApplicantID { get; set; }

        
        public virtual Applicant Applicant { get; set; }
    }
}
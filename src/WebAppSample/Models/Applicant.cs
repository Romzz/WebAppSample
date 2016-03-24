using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppSample.Models
{
    public class Applicant
    {
        [ScaffoldColumn(false)]
        public int ApplicantID { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        public virtual ICollection<Institution> Institution { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MiIT.Models
{
    public class Applicant
    {
        [Column("id")]
        [Display(Name = "ID")]
        public long Id { get; set; }

        [Column("full_name")]
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Enter Full Name")]
        [MaxLength(50, ErrorMessage = "Full Name must be <=50 characters in length")]
        public string? FullName { get; set; }

        [Column("date_of_birth")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Column("qualification")]
        [Display(Name = "Qualification")]
        [Required(ErrorMessage = "Enter Qualification")]
        public string? Qualification { get; set; }

        [Column("gpa")]
        [Display(Name = "GPA")]
        [Required(ErrorMessage = "Enter GPA")]
        [Range(3.0, 4.0, ErrorMessage = "GPA must be between 3.0 and 4.0")]
        public double? Gpa { get; set; }

        [Column("university")]
        [Display(Name = "University")]
        [Required(ErrorMessage = "Enter University")]
        [MinLength(2, ErrorMessage = "University must be between 2-50 characters in length")]
        [MaxLength(50, ErrorMessage = "University must be 2-50 characters in length")]
        public string? University { get; set; }

        // Qualification dropdown options
        public static readonly string[] QualificationOptions =
        {
            "Master of Data Science",
            "Master of Artificial Intelligence",
            "Master of Information Technology",
            "Master of Science (Statistics)"
        };

        [NotMapped]
        public IEnumerable<SelectListItem> QualificationSelectList
        {
            get
            {
                return QualificationOptions.Select(q => new SelectListItem
                {
                    Value = q,
                    Text = q,
                    Selected = (q == Qualification)
                });
            }
        }
    }

}



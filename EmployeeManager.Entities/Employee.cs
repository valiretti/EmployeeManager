using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public string Patronymic { get; set; }

        [Display(Name = "Employment date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime EmploymentDate { get; set; }

        public Position Position { get; set; }

        [Display(Name = "Company")]
        public int CompanyId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManager.Entities
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Size { get; set; }

        [Required]
        [Display(Name = "Legal form")]
        public string LegalForm { get; set; }
    }
}

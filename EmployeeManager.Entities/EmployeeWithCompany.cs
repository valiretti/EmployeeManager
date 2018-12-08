using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManager.Entities
{
    public class EmployeeWithCompany : Employee
    {
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
    }
}

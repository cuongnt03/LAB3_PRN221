using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LAB3.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }

        [EmailAddress(ErrorMessage = "Email address incorrect format.")]
        [Display(Name = "Email address (*)")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password (*)")]
        public string? Password { get; set; }
        public string? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public int? Role { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}

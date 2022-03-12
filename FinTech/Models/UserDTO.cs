using FinTech.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Models
{
    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your password is limited to 2 or 1 characters", MinimumLength = 8)]
        public string Password { get; set; }
    }
    public class UserDTO : LoginUserDTO
     {
        // public override int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        [Required]
        public int ContributionTypeId { get; set; }

        [Required]
        public ICollection<string> Roles { get; set; }

        // public ContributionType ContributionType { get; set; }
    }
}

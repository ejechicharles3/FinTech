using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Data
{
    public class Customer : IdentityUser
    {
       // public override int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }


        [ForeignKey(nameof(ContributionType))]
        public int ContributionTypeId { get; set; }
        public ContributionType ContributionType { get; set; }
  
       //customer's name, age, address, 	phone number, email and passport photograph
    }
}

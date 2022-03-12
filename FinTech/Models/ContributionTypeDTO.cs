using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Models
{
    public class CreateContributionTypeDTO
    {
        [Required]
        public string Name { get; set; }
    }
    public class ContributionTypeDTO : CreateContributionTypeDTO
    {
        public int Id { get; set; }
        public IList<ContributionDTO> Contributions { get; set; }
    } 
   
}

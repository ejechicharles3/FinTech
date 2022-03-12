using FinTech.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Models
{
    public class CreateContributionDTO
    {

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int ContributionTypeId { get; set; } 
        [Required]
        public string CustomerId { get; set; }
    } 
    public class ContributionDTO : CreateContributionDTO
    {
        public int Id { get; set; }

        public ContributionTypeDTO ContributionType { get; set; }
        public IList<ContributionTypeDTO> ContributionTypes { get; set; }//added by me not in the turorial
    }
}

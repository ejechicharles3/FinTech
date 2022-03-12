using FinTech.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech.Configurations.Entities
{
    public class ContributionTypeConfiguration : IEntityTypeConfiguration<ContributionType>
    {
        public void Configure(EntityTypeBuilder<ContributionType> builder)
        {
            builder.HasData(
              new ContributionType
              {
                  Id = 1,
                  Name = "Savings"
              },
              new ContributionType
              {
                  Id = 2,
                  Name = "End-Well"
              }
           );
        }
    }
}

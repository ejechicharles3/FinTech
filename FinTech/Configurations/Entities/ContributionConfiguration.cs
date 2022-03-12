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
    public class ContributionConfiguration : IEntityTypeConfiguration<Contribution>
    {
        public void Configure(EntityTypeBuilder<Contribution> builder)
        {
            builder.HasData(
                new Contribution
                {
                    Id = 1,
                    Date = DateTime.Now,
                    Time = DateTime.Now,
                    Amount = 1000,
                    ContributionTypeId = 1
                },
                new Contribution
                {
                    Id = 2,
                    Date = DateTime.Now,
                    Time = DateTime.Now,
                    Amount = 3000,
                    ContributionTypeId = 2
                },
                new Contribution
                {
                    Id = 3,
                    Date = DateTime.Now,
                    Time = DateTime.Now,
                    Amount = 3000,
                    ContributionTypeId = 1
                },
                new Contribution
                {
                    Id = 4,
                    Date = DateTime.Now,
                    Time = DateTime.Now,
                    Amount = 6000,
                    ContributionTypeId = 2
                }
             );

        }
    }
}

using FinTech.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace FinTech.Data
{
    public class DatabaseContext : IdentityDbContext<Customer>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Contribution> Contributions { get; set; }
        public DbSet<ContributionType> ContributionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ContributionConfiguration());
            builder.ApplyConfiguration(new ContributionTypeConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
        }
       
    }
}

using Microsoft.EntityFrameworkCore;
using organization.Domain.Entities;
using organization.infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace organization.infrastructure
{
    public class OrganizationDbContext:DbContext
    {
        public OrganizationDbContext(DbContextOptions<OrganizationDbContext> options) : base(options)
        {
        }
        public DbSet<Organization> Organizations => Set<Organization>();
        public DbSet<OrganizationContact> OrganizationContacts => Set<OrganizationContact>();
        public DbSet<OrganizationAddress> OrganizationAddresses => Set<OrganizationAddress>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("os");
            modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationAddressConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationContactConfiguration());
            base.OnModelCreating(modelBuilder);

        }
    }
}

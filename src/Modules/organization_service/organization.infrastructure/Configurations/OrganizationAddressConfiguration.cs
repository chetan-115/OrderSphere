using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using organization.Domain.Entities;
using organization.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace organization.infrastructure.Configurations
{
    public class OrganizationAddressConfiguration : IEntityTypeConfiguration<OrganizationAddress>
    {
        public void Configure(EntityTypeBuilder<OrganizationAddress> builder)
        {
            builder.ToTable("organization_addresses");
            builder.Property(x => x.Id).HasColumnName("id").HasDefaultValueSql(
                "gen_random_uuid()");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OrganizationId).HasColumnName("organization_id")
                .IsRequired();
            builder.Property(x => x.AddressType).HasColumnName("address_type")
                .HasConversion(value => (char)value, value => (AddressType)value)
                .IsRequired()
                .HasColumnType("char(1)");
            builder.Property(x => x.AddressLine1).HasColumnName("address_line1")
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(x => x.AddressLine2).HasColumnName("address_line2")
                .HasMaxLength(200);
            builder.Property(x => x.City).HasColumnName("city")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.State).HasColumnName("state")
                .HasMaxLength(100);
            builder.Property(x => x.PostalCode).HasColumnName("postal_code")
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(x => x.CountryCode).HasColumnName("country_code")
                .IsRequired()
                .HasMaxLength(2);
            builder.Property(x => x.IsPrimary).HasColumnName("is_primary")
                .HasDefaultValue(false)
                .IsRequired();
            builder.HasOne<Organization>()
                .WithMany()
                .HasForeignKey(x => x.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}

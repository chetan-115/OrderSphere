using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using organization.Domain;
using organization.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using organization.Domain.Enums;

namespace organization.infrastructure.Configurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("os_organizations");
            builder.Property(x => x.Id).HasColumnName("id").
                HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.Name).HasColumnName("name")
                .IsRequired()
                .HasMaxLength(150);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).HasColumnName("ozcode")
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.OrganizationType).HasColumnName("oztype")
                .HasConversion(value => (char)value, value => (OrganizationType)value)
                .IsRequired().HasColumnType("char(1)");
            builder.Property(x => x.OrganizationStatus).HasColumnName("status")
                .HasConversion(value => (char)value, value => (OrganizationStatus)value)
                .IsRequired().HasColumnType("char(1)");
            builder.Property(x => x.LegalName).HasColumnName("legal_name")
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(x => x.TaxRegistrationNumber).HasColumnName("tax_registration_number")
                .HasMaxLength(100);
            builder.Property(x => x.Email).HasColumnName("email")
                .IsRequired()
                .HasMaxLength(320);
            builder.Property(x => x.Phone).HasColumnName("phone_number")
                .HasMaxLength(20);
            builder.Property(x => x.Website).HasColumnName("website")
                .HasMaxLength(255);
            builder.Property(x => x.CreatedAtUtc).HasColumnName("created_at_utc").
                HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("now()")
                .IsRequired();
            builder.Property(x => x.UpdatedAtUtc).HasColumnName("updated_at_utc")
                .HasColumnType("timestamp with time zone");

        }

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using organization.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace organization.infrastructure.Configurations
{
    public class OrganizationContactConfiguration : IEntityTypeConfiguration<OrganizationContact>
    {
        public void Configure(EntityTypeBuilder<OrganizationContact> builder)
        {
            builder.ToTable("organization_contacts");
            builder.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql("gen_random_uuid()");
            builder.Property(x => x.OrganizationId).HasColumnName("organization_id")
                .IsRequired();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasColumnName("first_name")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.LastName).HasColumnName("last_name")
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Email).HasColumnName("email")
                .IsRequired()
                .HasMaxLength(350);
            builder.Property(x => x.PhoneNumber).HasColumnName("phone_number")
                .HasMaxLength(20);
            builder.Property(x => x.Designation).HasColumnName("designation")
                .HasMaxLength(100);
            builder.Property(x => x.IsPrimary).HasColumnName("is_primary")
                .HasDefaultValue(false)
                .IsRequired();
            builder.HasOne<Organization>().WithMany()
                .HasForeignKey(x => x.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict);  

        }

    }
}

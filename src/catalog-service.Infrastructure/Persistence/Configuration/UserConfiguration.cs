using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using catalog_service.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace catalog_service.Infrastructure.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.EmailAddress)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.HashPassword)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}

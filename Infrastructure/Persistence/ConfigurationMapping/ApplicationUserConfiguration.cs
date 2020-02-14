using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.ConfigurationMapping
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users");
            builder.Ignore(user => user.TwoFactorEnabled)
                   .Ignore(user => user.LockoutEnabled)
                   .Ignore(user => user.LockoutEnd)
                   .Ignore(user => user.PhoneNumberConfirmed)
                   .Ignore(user => user.EmailConfirmed)
                   .Ignore(user => user.AccessFailedCount);

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(new
            {
                Id = new Guid("a14280f8-d2b9-4598-8c89-c699cd1ab278"),
                UserName = "Rasmus Bak Petersen",
                NormalizedUserName = "ADMINDEV@HOTMAIL.COM",
                Email = "adminDev@hotmail.coM",
                NormalizedEmail = "ADMINDEV@HOTMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "Horse123!"),
                SecurityStamp = "f4572cb1-6f71-46fd-8260-0baea7287367",
                ConcurrencyStamp = "bd5b9857-9d78-4f9d-81e3-28569973e0a2",
                PhoneNumber = "28929173",
            });
        }
    }
}

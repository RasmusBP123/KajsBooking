using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.ConfigurationMapping.Policies
{
    public class TeacherRoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.HasData(new IdentityRole<Guid>
            {
                Id = new Guid("3b1dd839-7407-4041-9b67-20f3b5bd3e29"),
                Name = "Teacher",
                NormalizedName = "TEACHER",
            });
        }
    }
}

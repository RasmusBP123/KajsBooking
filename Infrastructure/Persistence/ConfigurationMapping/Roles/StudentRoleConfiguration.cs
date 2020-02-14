using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.ConfigurationMapping.Policies
{
    public class StudentRoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.HasData(new IdentityRole<Guid> { Id = new Guid("dbb59868-4c1b-4afb-8bc7-b49552857bf4")
                                               ,Name = "Student"
                                               ,NormalizedName = "STUDENT"
            });
        }
    }
}

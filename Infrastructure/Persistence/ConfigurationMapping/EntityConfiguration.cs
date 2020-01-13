using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.ConfigurationMapping
{
    public class EntityConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("Todos");

            builder.HasData(new Todo
            {
                Id = new Guid("b15bd5d8-b161-4b0e-8255-85b02e8e897d"),
                Name = "Do Dished",
                Created = DateTime.Now,
                CreatedBy = "Me",
            });
        }
    }
}

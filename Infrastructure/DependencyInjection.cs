using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.Common.Interfaces;
using Infrastructure.Identity;
using System;
using Microsoft.AspNetCore.Identity;
using Domain.Entities;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)));

            services.AddDefaultIdentity<ApplicationUser>()
                    .AddRoles<IdentityRole<Guid>>()
                    .AddEntityFrameworkStores<ApplicationDBContext>()
                    .AddDefaultTokenProviders();

            services.AddAuthorization(config =>
            {
                config.AddPolicy(Policies.IsTeacher, Policies.IsTeacherPolicy());
                config.AddPolicy(Policies.IsStudent, Policies.IsStudentPolicy());
            });

            services.AddScoped<IApplicationDBContext>(provider => provider.GetService<ApplicationDBContext>());

            return services;
        }
    }
}

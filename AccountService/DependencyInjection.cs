using AccountService.Interfaces;
using AccountService.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountService
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterAccountServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            return services;
        }
    }
}

using Application.Common.Mappings;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }

        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(profile =>
            {
                profile.AddProfile(new DomainToViewModelProfile());
                profile.AddProfile(new ViewModelToDomainProfile());
            });
        }

        public static void AddAutoMapperSetup(this IServiceCollection services, params Assembly[] assemblies)
        {
            var config = RegisterMappings();
            var mapper = config.CreateMapper();

            IEnumerable<Profile> profiles = new List<Profile>() { new DomainToViewModelProfile(), new ViewModelToDomainProfile() };
            services.AddAutoMapper(config => config.AddProfiles(profiles), assemblies);
        }
    }
}

using Application.Common.Mappings;
using Application.UseCases.CreateBooking;
using Application.UseCases.CreateTimeslot;
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
            services.RegisterCommands();
            services.RegisterQueries();

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
        private static void RegisterCommands(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateTimeslotCommand, bool>, CreateTimeSlotHandler>();
            services.AddScoped<IRequestHandler<CreateBookingCommand, bool>, CreateBookingHandler>();
        }

        private static void RegisterQueries(this IServiceCollection services)
        {

        }
    }
}

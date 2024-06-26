﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SolarLab.Academy.ComponentRegistrar.Mappers;

namespace SolarLab.Academy.ComponentRegistrar
{
    public static class Registrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.ConfigureAutomapper();
        }

        private static IServiceCollection ConfigureAutomapper(this IServiceCollection services)
        {
            return services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
        }

        private static MapperConfiguration GetMapperConfiguration() 
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<FileProfile>();
                cfg.AddProfile<CategoryProfile>();
            });
            config.AssertConfigurationIsValid();
            return config;
        }
    }
}

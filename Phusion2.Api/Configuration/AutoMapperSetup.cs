using Microsoft.Extensions.DependencyInjection;
using Phusion2.Application.AutoMapper;
using System;

namespace Phusion2.Api.Configuration
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(Startup));

            AutoMapperConfig.RegisterMappings();
        }
    }
}

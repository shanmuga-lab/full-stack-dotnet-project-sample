using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Catalog.Application
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // Register your services here
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}

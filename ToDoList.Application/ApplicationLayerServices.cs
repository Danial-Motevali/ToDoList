﻿using Microsoft.Extensions.DependencyInjection;

namespace ToDoList.Application
{
    public static class ApplicationLayerServices
    {
        public static void AddApplicatiouLayerServices(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssemblies(typeof(ApplicationLayerServices).Assembly));
        }
    }
}

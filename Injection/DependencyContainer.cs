using DataAccess.Repository;
using Domain.Abstract.Entity.Logic;
using Domain.Abstract.Repositories;
using Domain.Entity.Logic;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Injection
{
    public static class Dependencycontainer
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IContentRepository, ContentRepository>();
            services.AddScoped<IContentLogic, ContentLogic>();
            return services;
        }
    }
}

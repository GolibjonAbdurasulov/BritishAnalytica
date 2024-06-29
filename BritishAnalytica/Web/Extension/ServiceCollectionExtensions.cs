using System;
using System.Reflection;
using System.Text;
using Castle.Core.Configuration;
using DatabaseBroker;
using DatabaseBroker.Repositories.Common;
using Entity.Attributes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.Interfaces;
using Services.Services;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Web.Extension;

public static class ServiceCollectionExtensions
{
    public static void ConfigureRepositories(this IServiceCollection serviceCollection)
    {
        foreach (Type type in Assembly.GetAssembly(typeof(RepositoryBase<,>))!.GetTypes()
                     .Where(x => x.BaseType is not null && x.BaseType.IsGenericType &&
                                 x.BaseType.GetGenericTypeDefinition() == (typeof(RepositoryBase<,>)) &&
                                 x.GetCustomAttribute<InjectableAttribute>() is not null))
        {
            serviceCollection.AddScoped(type.GetInterfaces().LastOrDefault()!, type);
        }
    }

    public static void ConfigureServicesFromTypeAssembly<T>(this IServiceCollection serviceCollection)
    {
        foreach (var type in Assembly.GetAssembly(typeof(T))!.GetTypes()
                     .Where(x => x.GetCustomAttribute<InjectableAttribute>() != null))
        {
            var attr = type.GetCustomAttribute<InjectableAttribute>()!;

            if (type.GetInterfaces().Length != 0 && !attr.WithoutInterface)
                serviceCollection.Add(new ServiceDescriptor(type.GetInterfaces().LastOrDefault()!, type,
                    attr.IsSingleton ? ServiceLifetime.Singleton : ServiceLifetime.Scoped));
            else
                serviceCollection.Add(new ServiceDescriptor(type, type,
                    attr.IsSingleton ? ServiceLifetime.Singleton : ServiceLifetime.Scoped));

        }
    }
    
}
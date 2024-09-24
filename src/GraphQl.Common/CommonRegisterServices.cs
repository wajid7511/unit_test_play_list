using System;
using GraphQl.Abstraction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQl.Common;

public class CommonRegisterServices : IServiceRegistrationModule
{
    public void RegisterServices(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddSingleton<IDateTimeProvider, DefaultDateTimeProvider>();
    }
}

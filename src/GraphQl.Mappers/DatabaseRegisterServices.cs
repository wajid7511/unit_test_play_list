using GraphQl.Abstraction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQl.Mappers;

public class DatabaseRegisterServices : IServiceRegistrationModule
{
    public void RegisterServices(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddAutoMapper(typeof(PatientProfile));
    }
}

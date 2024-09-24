using GraphQl.Abstraction;
using GraphQl.Abstraction.Patients;
using GraphQl.Core.Patients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQl.Core;

public class CoreRegisterServices : IServiceRegistrationModule
{
    public void RegisterServices(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<IPatientManager, DefaultPatientManager>();
    }
}

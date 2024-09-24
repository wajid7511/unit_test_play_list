using GraphQl.Abstraction;
using GraphQl.DataBase.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQl.DataBase;

public class DatabaseRegisterServices : IServiceRegistrationModule
{
    public void RegisterServices(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<GraphQlUnitTestDatabaseContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("Default"))
        );
        services.AddScoped<PatientDAL>();
    }
}

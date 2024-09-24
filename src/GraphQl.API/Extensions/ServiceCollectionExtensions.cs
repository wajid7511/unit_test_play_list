using System.Reflection;
using GraphQl.Abstraction;
using GraphQl.API.Mutations;
using GraphQl.API.Queries;
using GraphQl.DataBase;

namespace GraphQl.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterGraphQlDemoIServicesRegisterModules(
        this IServiceCollection services,
        ConfigurationManager configuration
    )
    {
        try
        {
            var assemblies = Directory
                .GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                .Select(Assembly.LoadFrom)
                .ToArray();

            var moduleTypes = assemblies
                .SelectMany(a => a.GetTypes())
                .Where(
                    t =>
                        typeof(IServiceRegistrationModule).IsAssignableFrom(t)
                        && !t.IsInterface
                        && !t.IsAbstract
                );

            foreach (var moduleType in moduleTypes)
            {
                var moduleInstance = Activator.CreateInstance(moduleType);
                if (moduleInstance is not null)
                {
                    var module = (IServiceRegistrationModule)moduleInstance;
                    module?.RegisterServices(services, configuration);
                }
            }
        }
        catch (ReflectionTypeLoadException ex)
        {
            Console.WriteLine("ReflectionTypeLoadException caught:");
            foreach (var loaderException in ex.LoaderExceptions)
            {
                Console.WriteLine("Error:" + loaderException?.ToString() ?? "No Exception");
            }
        }
    }

    public static IServiceCollection AddGraphQl(this IServiceCollection services)
    {
        services
            .AddDbContext<GraphQlUnitTestDatabaseContext>()
            .AddGraphQLServer()
            .AddMutationType<Mutation>()
            .AddTypeExtension<PatientMutation>()
            .AddQueryType<Query>()
            .AddProjections()
            .AddFiltering()
            .AddSorting();
        return services;
    }
}

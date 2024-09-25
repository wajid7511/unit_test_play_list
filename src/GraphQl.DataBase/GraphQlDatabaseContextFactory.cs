using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GraphQl.DataBase;

public class GraphQlDatabaseContextFactory : IDesignTimeDbContextFactory<GraphQlUnitTestDatabaseContext>
{
    public GraphQlUnitTestDatabaseContext CreateDbContext(string[] args)
    {
        // Configuration for design-time services
        var optionsBuilder = new DbContextOptionsBuilder<GraphQlUnitTestDatabaseContext>();

        // Use your connection string or configure the options here
        optionsBuilder.UseSqlServer(
            "Server=localhost; Database=GraphQlUnitTest; User ID=SA;Password=YOURPASSWORD;TrustServerCertificate=true;"
        );

        return new GraphQlUnitTestDatabaseContext(optionsBuilder.Options);
    }
}

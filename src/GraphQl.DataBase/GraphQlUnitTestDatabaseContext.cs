using GraphQl.Abstraction;
using GraphQl.DataBase.Configurations;
using GraphQl.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQl.DataBase;

public class GraphQlUnitTestDatabaseContext : DbContext
{
    private readonly IDateTimeProvider _dateTimeProvider = null!;

    public GraphQlUnitTestDatabaseContext(DbContextOptions<GraphQlUnitTestDatabaseContext> options)
        : base(options) { }

    public GraphQlUnitTestDatabaseContext(
        DbContextOptions<GraphQlUnitTestDatabaseContext> options,
        IDateTimeProvider dateTimeProvider
    )
        : base(options)
    {
        _dateTimeProvider =
            dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost; Database=GraphQlUnitTest; User ID=SA;Password=YOURPASSWORD;TrustServerCertificate=true;"
            );
        }
    }

    public override int SaveChanges()
    {
        SetAuditDates();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default
    )
    {
        SetAuditDates();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void SetAuditDates()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(
                e =>
                    e.Entity is DbBaseModel
                    && (e.State == EntityState.Added || e.State == EntityState.Modified)
            );

        foreach (var entry in entries)
        {
            var entity = (DbBaseModel)entry.Entity;

            if (entry.State == EntityState.Added)
            {
                entity.CreatedOn = _dateTimeProvider.UtcNow;
            }
            if (entry.State == EntityState.Modified)
            {
                entity.LastUpdateTime = _dateTimeProvider.UtcNow;
            }
        }
    }

    public DbSet<Patient> Patients { get; set; }
}

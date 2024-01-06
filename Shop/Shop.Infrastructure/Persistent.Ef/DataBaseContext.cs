using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.UserAgg;

namespace Shop.Infrastructure.Persistent.Ef;

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataBaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<User> Users { get; set; }
}


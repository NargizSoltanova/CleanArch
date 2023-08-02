using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using practice.Application.Common.Interfaces;
using practice.Domain.Entities;
using practice.Domain.Identity;
using System.Reflection;

namespace practice.Infrastructure.Persistance;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    public DbSet<Team> Teams => Set<Team>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.Entity<AppRole>().HasData(new AppRole { Name = "admin" });
        builder.Entity<AppRole>().HasData(new AppRole { Name = "member" });
        base.OnModelCreating(builder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}

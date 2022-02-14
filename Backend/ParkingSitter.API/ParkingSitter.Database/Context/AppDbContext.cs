using Microsoft.EntityFrameworkCore;
using ParkingSitter.Domain.Model;

namespace ParkingSitter.Database.Context;

public  class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    public DbSet<Users> Users { get; set; }
    public DbSet<Parkings> Parkings { get; set; }
    public DbSet<Transactions> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsersMap());
        modelBuilder.ApplyConfiguration(new ParkingsMap());
        modelBuilder.ApplyConfiguration(new TransactionsMap());
        base.OnModelCreating(modelBuilder);
    }
}


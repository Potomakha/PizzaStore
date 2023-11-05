using Microsoft.EntityFrameworkCore;
using PizzaStore.Entities;

namespace PizzaStore.Repositories;

public class ProductDbContext : DbContext
{
    public DbSet<ProductEntity> ProductEntities { get; set; } = null!;

    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductEntity>(entity =>
        {
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
            entity.Property(p => p.DateCreated).ValueGeneratedOnAdd();
            entity.Property(p => p.DateModified).ValueGeneratedOnAddOrUpdate();
        });
    }
}
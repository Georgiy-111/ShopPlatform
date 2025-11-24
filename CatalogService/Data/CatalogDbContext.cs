using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Data;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
        : base(options)
    {
    }

    // Набор сущностей (таблица Products в БД)
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Конфигурация сущности Product
        modelBuilder.Entity<Product>(entity =>
        {
            // Имя таблицы
            entity.ToTable("Products");

            // Первичный ключ
            entity.HasKey(p => p.Id);

            // Свойства
            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(p => p.Category)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(p => p.Price)
                .HasColumnType("numeric(18,2)");

            entity.Property(p => p.Stock);
        });
    }
}
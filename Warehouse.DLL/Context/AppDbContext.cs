using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.DAL.Context
{
    public class AppDbContext : DbContext
    {
        // Constructor accepting DbContextOptions
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for your entities
        public DbSet<Product> Products { get; set; }
        public DbSet<WarehouseManagement.Domain.Entities.Warehouse> Warehouses { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }

        // Override OnModelCreating for custom configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API configurations

            // Configure Product entity
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductID);

            // Configure Warehouse entity
            modelBuilder.Entity<WarehouseManagement.Domain.Entities.Warehouse>()
                .HasKey(w => w.WarehouseID);

            // Configure StockMovement entity
            modelBuilder.Entity<StockMovement>()
                .HasKey(sm => sm.MovementID);

            // Relationships
            modelBuilder.Entity<StockMovement>()
                .HasOne(sm => sm.Product)
                .WithMany(p => p.StockMovements)
                .HasForeignKey(sm => sm.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StockMovement>()
                .HasOne(sm => sm.Warehouse)
                .WithMany(w => w.StockMovements)
                .HasForeignKey(sm => sm.WarehouseID)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

            // Seed Products
            base.OnModelCreating(modelBuilder);

            // Seed data for Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductID = 1,
                    ProductName = "Laptop",
                    SizePerUnit = 15.6f,
                    IsHazardous = false
                },
                new Product
                {
                    ProductID = 2,
                    ProductName = "Smartphone",
                    SizePerUnit = 6.1f,
                    IsHazardous = false
                },
                new Product
                {
                    ProductID = 3,
                    ProductName = "Lithium Battery",
                    SizePerUnit = 0.5f,
                    IsHazardous = true
                }
            );

            // Seed data for Warehouses
            modelBuilder.Entity<Domain.Entities.Warehouse>().HasData(
                new Domain.Entities.Warehouse
                {
                    WarehouseID = 1,
                    WarehouseName = "New York"
                },
                new Domain.Entities.Warehouse
                {
                    WarehouseID = 2,
                    WarehouseName = "New York"
                },
                new Domain.Entities.Warehouse
                {
                    WarehouseID = 3,
                    WarehouseName = "Chicago"
                }
            );

            // Seed data for StockMovements
            modelBuilder.Entity<StockMovement>().HasData(
                new StockMovement
                {
                    MovementID = 1,
                    ProductID = 1, // Laptop
                    WarehouseID = 1, // New York
                    
                },
                new StockMovement
                {
                    MovementID = 2,
                    ProductID = 2, // Smartphone
                    WarehouseID = 2, // Los Angeles                    
                },
                new StockMovement
                {
                    MovementID = 3,
                    ProductID = 3, // Lithium Battery
                    WarehouseID = 3, // Chicago                    
                }
            );

        }
    }
}

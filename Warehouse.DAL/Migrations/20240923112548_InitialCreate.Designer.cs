﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarehouseManagement.DAL.Context;

#nullable disable

namespace Warehouse.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240923112548_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WarehouseManagement.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"), 1L, 1);

                    b.Property<bool>("IsHazardous")
                        .HasColumnType("bit");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("SizePerUnit")
                        .HasColumnType("real");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WarehouseManagement.Domain.Entities.StockMovement", b =>
                {
                    b.Property<int>("MovementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovementID"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsImport")
                        .HasColumnType("bit");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("WarehouseID")
                        .HasColumnType("int");

                    b.HasKey("MovementID");

                    b.HasIndex("ProductID");

                    b.HasIndex("WarehouseID");

                    b.ToTable("StockMovements");
                });

            modelBuilder.Entity("WarehouseManagement.Domain.Entities.Warehouse", b =>
                {
                    b.Property<int>("WarehouseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WarehouseID"), 1L, 1);

                    b.Property<bool>("IsHazardousOnly")
                        .HasColumnType("bit");

                    b.Property<float>("MaxStockAmount")
                        .HasColumnType("real");

                    b.Property<string>("WarehouseName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("WarehouseID");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("WarehouseManagement.Domain.Entities.StockMovement", b =>
                {
                    b.HasOne("WarehouseManagement.Domain.Entities.Product", "Product")
                        .WithMany("StockMovements")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WarehouseManagement.Domain.Entities.Warehouse", "Warehouse")
                        .WithMany("StockMovements")
                        .HasForeignKey("WarehouseID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("WarehouseManagement.Domain.Entities.Product", b =>
                {
                    b.Navigation("StockMovements");
                });

            modelBuilder.Entity("WarehouseManagement.Domain.Entities.Warehouse", b =>
                {
                    b.Navigation("StockMovements");
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Warehouse.Data.SQLite
{
    public partial class WarehouseSQLiteContext : DbContext
    {
        public WarehouseSQLiteContext()
        {
        }

        public WarehouseSQLiteContext(DbContextOptions<WarehouseSQLiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<LineItem> LineItems { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<ShippingProvider> ShippingProviders { get; set; } = null!;
        public virtual DbSet<Warehouse> Warehouses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlite("Data source=D:\\DATA ACCESS\\03\\demos\\Start_Here\\WarehouseManagementSystem\\WarehouseManagementSystem\\warehouse.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasMany(d => d.Warehouses)
                    .WithMany(p => p.Items)
                    .UsingEntity<Dictionary<string, object>>(
                        "ItemWarehouse",
                        l => l.HasOne<Warehouse>().WithMany().HasForeignKey("WarehousesId"),
                        r => r.HasOne<Item>().WithMany().HasForeignKey("ItemsId"),
                        j =>
                        {
                            j.HasKey("ItemsId", "WarehousesId");

                            j.ToTable("ItemWarehouse");

                            j.HasIndex(new[] { "WarehousesId" }, "IX_ItemWarehouse_WarehousesId");
                        });
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.ToTable("LineItem");

                entity.HasIndex(e => e.ItemId, "LineItem_IX_LineItem_ItemId");

                entity.HasIndex(e => e.OrderId, "LineItem_IX_LineItem_OrderId");

                entity.Property(e => e.Id).HasColumnType("text");

                entity.Property(e => e.ItemId).HasColumnType("text");

                entity.Property(e => e.OrderId).HasColumnType("text");

                entity.Property(e => e.Quantity).HasColumnType("bigint");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.ItemId);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.OrderId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.CustomerId, "IX_Orders_CustomerId");

                entity.HasIndex(e => e.ShippingProviderId, "IX_Orders_ShippingProviderId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.ShippingProvider)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShippingProviderId);
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouse");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

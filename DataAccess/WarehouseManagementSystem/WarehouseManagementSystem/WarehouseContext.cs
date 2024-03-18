﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WarehouseManagementSystem
{
    public partial class WarehouseContext : DbContext
    {
        public WarehouseContext()
        {
        }

        public WarehouseContext(DbContextOptions<WarehouseContext> options)
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Data Access\\02\\demos\\Windows\\Start_Here\\WarehouseManagement.mdf");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

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

                entity.HasIndex(e => e.ItemId, "IX_LineItem_ItemId");

                entity.HasIndex(e => e.OrderId, "IX_LineItem_OrderId");

                entity.HasIndex(e => e.ShippingProviderId, "IX_LineItem_ShippingProviderId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.ItemId);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.ShippingProvider)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.ShippingProviderId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.CustomerId, "IX_Orders_CustomerId");

                entity.HasIndex(e => e.ShippingProviderId, "IX_Orders_ShippingProviderId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.ShippingProvider)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShippingProviderId);
            });

            modelBuilder.Entity<ShippingProvider>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FreightCost).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouse");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
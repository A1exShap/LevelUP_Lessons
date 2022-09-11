using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DataAccess.DTO;

namespace DataAccess.DBContext
{
    public partial class SportsStoreItemsContext : DbContext
    {
        public SportsStoreItemsContext()
        {
        }

        public SportsStoreItemsContext(DbContextOptions<SportsStoreItemsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<ItemProperty> ItemProperties { get; set; } = null!;
        public virtual DbSet<ItemPropertyValue> ItemPropertyValues { get; set; } = null!;
        public virtual DbSet<ItemType> ItemTypes { get; set; } = null!;
        public virtual DbSet<PropertyEnum> PropertyEnums { get; set; } = null!;
        public virtual DbSet<PropertyEnumValue> PropertyEnumValues { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-IVFJ6ER\\SQLEXPRESS;Database=SportsStoreItems;User Id=sa;Password=1;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.HasOne(d => d.ItemTypes)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Items_ItemTypes");
            });

            modelBuilder.Entity<ItemProperty>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.ItemType)
                    .WithMany(p => p.ItemProperties)
                    .HasForeignKey(d => d.ItemTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemProperties_ItemTypes");
            });

            modelBuilder.Entity<ItemPropertyValue>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.PropertyId, e.ItemId })
                    .HasName("PK_ProductPropertyValues");

                entity.Property(e => e.NumericValue).HasColumnType("numeric(28, 6)");

                entity.Property(e => e.StringValue).HasMaxLength(500);

                entity.HasOne(d => d.EnumValue)
                    .WithMany(p => p.ItemPropertyValues)
                    .HasForeignKey(d => d.EnumValueId)
                    .HasConstraintName("FK_ItemPropertyValues_EnumValues");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemPropertyValues)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemPropertyValues_Items");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.ItemPropertyValues)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemPropertyValues_ItemProperties");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<PropertyEnum>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<PropertyEnumValue>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NumericValue).HasColumnType("numeric(28, 6)");

                entity.Property(e => e.StringValue).HasMaxLength(200);

                entity.HasOne(d => d.Enum)
                    .WithMany(p => p.PropertyEnumValues)
                    .HasForeignKey(d => d.EnumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EnumValues_Enums");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

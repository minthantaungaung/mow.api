using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api.mov.Models
{
    public partial class db_a8f2df_4fandaContext : DbContext
    {
        public db_a8f2df_4fandaContext()
        {
        }

        public db_a8f2df_4fandaContext(DbContextOptions<db_a8f2df_4fandaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Doner> Doners { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Relationship> Relationships { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Volunteer> Volunteers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=MYSQL8001.site4now.net;database=db_a8f2df_4fanda;uid=a8f2df_4fanda;pwd=admin1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_unicode_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomerID");

                entity.Property(e => e.Age).HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.CustomerName).HasMaxLength(255);

                entity.Property(e => e.DetailedAddress).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.Township).HasMaxLength(255);
            });

            modelBuilder.Entity<Doner>(entity =>
            {
                entity.ToTable("doner");

                entity.Property(e => e.DonerId)
                    .ValueGeneratedNever()
                    .HasColumnName("DonerID");

                entity.Property(e => e.DonatedPrice).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.IsMember).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.Pwd).HasMaxLength(255);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderID");

                entity.Property(e => e.OrderDatetime).HasMaxLength(255);

                entity.Property(e => e.OrderDesc).HasMaxLength(255);

                entity.Property(e => e.OrderNo).HasMaxLength(255);

                entity.Property(e => e.VolundeerId)
                    .HasMaxLength(255)
                    .HasColumnName("VolundeerID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductID");

                entity.Property(e => e.Image).HasMaxLength(255);

                entity.Property(e => e.ProductCode).HasMaxLength(255);

                entity.Property(e => e.ProductDesc).HasMaxLength(255);
            });

            modelBuilder.Entity<Relationship>(entity =>
            {
                entity.ToTable("relationship");

                entity.Property(e => e.RelationshipId)
                    .ValueGeneratedNever()
                    .HasColumnName("RelationshipID");

                entity.Property(e => e.ChildId).HasColumnName("ChildID");

                entity.Property(e => e.ChildTableName).HasMaxLength(255);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.ParentTableName).HasMaxLength(255);

                entity.Property(e => e.Udef1)
                    .HasMaxLength(255)
                    .HasColumnName("UDEF1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.Role).HasMaxLength(255);
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.ToTable("volunteer");

                entity.Property(e => e.VolunteerId)
                    .ValueGeneratedNever()
                    .HasColumnName("VolunteerID");

                entity.Property(e => e.CurrentStatus).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

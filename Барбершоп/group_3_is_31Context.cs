using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Барбершоп
{
    public partial class group_3_is_31Context : DbContext
    {
        public group_3_is_31Context()
        {
        }

        public group_3_is_31Context(DbContextOptions<group_3_is_31Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Barber> Barbers { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ProvisionOfService> ProvisionOfServices { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server=192.168.0.94;port=3306;user=group_3_is_31;password=09y9uu;database=group_3_is_31");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barber>(entity =>
            {
                entity.ToTable("barbers");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Contact).HasMaxLength(11);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Patronimyc)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Contact).HasMaxLength(11);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ProvisionOfService>(entity =>
            {
                entity.ToTable("provision_of_services");

                entity.HasIndex(e => e.Barber, "FK_provision_of_services_barbers");

                entity.HasIndex(e => e.Client, "FK_provision_of_services_clients");

                entity.HasIndex(e => e.Service, "FK_provision_of_services_services");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Price).HasColumnType("decimal(14,1)");

                entity.HasOne(d => d.BarberNavigation)
                    .WithMany(p => p.ProvisionOfServices)
                    .HasForeignKey(d => d.Barber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_provision_of_services_barbers");

                entity.HasOne(d => d.ClientNavigation)
                    .WithMany(p => p.ProvisionOfServices)
                    .HasForeignKey(d => d.Client)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_provision_of_services_clients");

                entity.HasOne(d => d.ServiceNavigation)
                    .WithMany(p => p.ProvisionOfServices)
                    .HasForeignKey(d => d.Service)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_provision_of_services_services");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Role1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Role");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("services");

                entity.HasIndex(e => e.Material, "FK_services_storage");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.MaterialNavigation)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.Material)
                    .HasConstraintName("FK_services_storage");
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.ToTable("storage");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Material)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Postav)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Role, "FK_users_roles");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Contact).HasMaxLength(11);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Role)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

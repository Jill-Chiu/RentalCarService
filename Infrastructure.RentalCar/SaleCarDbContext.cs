using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RentalCar;

public partial class SaleCarDbContext : DbContext
{
    public SaleCarDbContext()
    {
    }

    public SaleCarDbContext(DbContextOptions<SaleCarDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<CarEntity> Cars { get; set; }

    public virtual DbSet<RentalCar> RentalCars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
        if (optionsBuilder.IsConfigured)
        {
           //optionsBuilder.UseSqlServer(); 
        }
    }
        // => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=SaleCarDB; Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC075022F386");

            entity.ToTable("Account");

            entity.Property(e => e.Aid)
                .HasMaxLength(50)
                .HasColumnName("AID");
            entity.Property(e => e.ChtName).HasMaxLength(50);
            entity.Property(e => e.MobilePhone).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<CarEntity>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cc).HasColumnName("cc");
            entity.Property(e => e.ManufacturingDate).HasColumnType("datetime");
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(200);
        });

        modelBuilder.Entity<RentalCar>(entity =>
        {
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.CarType).HasMaxLength(200);
            entity.Property(e => e.RentalEndTime).HasColumnType("datetime");
            entity.Property(e => e.RentalStartTime).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

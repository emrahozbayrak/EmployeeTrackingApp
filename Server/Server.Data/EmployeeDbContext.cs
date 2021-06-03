using Microsoft.EntityFrameworkCore;
using Server.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data
{
    public partial class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {

        }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeHistory> EmployeeHistory { get; set; }
        public virtual DbSet<StatusType> StatusType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.MobileUsername).HasMaxLength(20);

                entity.Property(e => e.MobilePassword).HasMaxLength(20);
            });

            modelBuilder.Entity<EmployeeHistory>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Latitude).HasMaxLength(50);

                entity.Property(e => e.Longitude).HasMaxLength(50);

                entity.Property(e => e.LocationTime).HasColumnType("datetime");

                entity.HasOne(d => d.Employee);

                entity.HasOne(d => d.StatusType);
            });

            modelBuilder.Entity<StatusType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StatusName).HasMaxLength(50);

                // Veritabanında oluşturlacak tabloya varsayılan data bilgileri ekleniyor.
                entity.HasData(
                    new StatusType
                    {
                        Id = 0,
                        StatusName = "Mesai Başladı"
                    },
                    new StatusType
                    {
                        Id = 1,
                        StatusName = "Mesai Tamalandı"
                    },
                    new StatusType
                    {
                        Id = 2,
                        StatusName = "İzinli"
                    }
                );
            });

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

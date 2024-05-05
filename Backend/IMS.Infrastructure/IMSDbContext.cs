using IMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace IMS.Infrastructure.Entities
{
    public class IMSDbContext : DbContext
    {
        public IMSDbContext(DbContextOptions<IMSDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Device> Devices { get; set; }

        public DbSet<EmployeeDevice> EmployeeDevices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .ToTable("Employee")
                .HasMany(e => e.Devices)
                .WithMany()
                .UsingEntity<EmployeeDevice>(
                ed =>
                {
                    ed.Property(p => p.AssignedDate).IsRequired();
                    ed.Property(p => p.ReturnDate).HasColumnName("ReturnDate");
                    ed.Property(p => p.DateCreated).HasDefaultValue(DateTimeOffset.UtcNow);

                }
                )
                .Property(p => p.DateCreated).HasDefaultValue(DateTimeOffset.UtcNow);

            modelBuilder.Entity<Device>()
                .ToTable("Device")
                .Property(p => p.DateCreated).HasDefaultValue(DateTimeOffset.UtcNow);

            modelBuilder.Entity<EmployeeDevice>()
                 .ToTable("EmployeeDevice");


            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "Frodo", LastName = "Baggins", Email = "frodo.baggins@lotr.dev" },
                new Employee { Id = 2, FirstName = "Samwise", LastName = "Gamgee", Email = "samwise.gamgee@lotr.dev" }
                );

            modelBuilder.Entity<Device>().HasData(
                new Device { Id = 1, Name = "Lenovo LOQ", Description = "Legion Series", Type = DeviceType.Laptop, Shared = false, BarCode = "123456789" },
                new Device { Id = 2, Name = "ONE PLUS Nord", Description = "ONE Plus Nord 5G", Type = DeviceType.Mobile, Shared = false, BarCode = "123456790" },
                new Device { Id = 3, Name = "Cisco IP phone", Description = "Cisco IP phone for the cubicle", Type = DeviceType.DeskPhone, Shared = true, BarCode = "123456791" }
                );
        }
    }


}

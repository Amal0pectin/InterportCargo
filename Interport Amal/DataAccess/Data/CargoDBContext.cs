using Microsoft.EntityFrameworkCore;
using Interport_Amal.BusinessLogic.Entities;
using System.Collections.Generic;

namespace Interport_Amal.DataAccess.Data
{
    public class CargoDBContext : DbContext
    {

        public CargoDBContext(DbContextOptions<CargoDBContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        //public DbSet<Quotation> Quotations { get; set; }
        //public DbSet<QuotationRequest> QuotationRequests { get; set; }
        public DbSet<RateSchedule> RateSchedule { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<RateSchedule>().ToTable("RateSchedule").HasData(
                new RateSchedule { Id = 1, ServiceType = "Walf Booking fee", ContainerType = "20 Feet Container", Rate = 60.0m },
                new RateSchedule { Id = 2, ServiceType = "Walf Booking fee", ContainerType = "40 Feet Container", Rate = 70.0m },
                new RateSchedule { Id = 3, ServiceType = "Lift on/Lif Off", ContainerType = "20 Feet Container", Rate = 80.0m },
                new RateSchedule { Id = 4, ServiceType = "Lift on/Lif Off", ContainerType = "40 Feet Container", Rate = 120.0m },
                new RateSchedule { Id = 5, ServiceType = "Fumigation", ContainerType = "20 Feet Container", Rate = 220.0m },
                new RateSchedule { Id = 6, ServiceType = "Fumigation", ContainerType = "40 Feet Container", Rate = 280.0m },
                new RateSchedule { Id = 7, ServiceType = "LCL Delivery Depot", ContainerType = "20 Feet Container", Rate = 400.0m },
                new RateSchedule { Id = 8, ServiceType = "LCL Delivery Depot", ContainerType = "40 Feet Container", Rate = 500.0m },
                new RateSchedule { Id = 9, ServiceType = "Tailgate Inspection", ContainerType = "20 Feet Container", Rate = 120.0m },
                new RateSchedule { Id = 10, ServiceType = "Tailgate Inspection", ContainerType = "40 Feet Container", Rate = 160.0m },
                new RateSchedule { Id = 11, ServiceType = "Storage Fee", ContainerType = "20 Feet Container", Rate = 240.0m },
                new RateSchedule { Id = 12, ServiceType = "Storage Fee", ContainerType = "40 Feet Container", Rate = 300.0m },
                new RateSchedule { Id = 13, ServiceType = "Facility Fee", ContainerType = "20 Feet Container", Rate = 70.0m },
                new RateSchedule { Id = 14, ServiceType = "Facility Fee", ContainerType = "40 Feet Container", Rate = 100.0m },
                new RateSchedule { Id = 15, ServiceType = "Warf Inspection", ContainerType = "20 Feet Container", Rate = 60.0m },
                new RateSchedule { Id = 16, ServiceType = "Warf Inspection", ContainerType = "40 Feet Container", Rate = 90.0m }
                );

        }

        
    }



    
}
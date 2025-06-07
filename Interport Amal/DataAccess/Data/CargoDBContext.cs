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
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuotationRequest> QuotationRequests { get; set; }
        public DbSet<QuotationItem> QuotationItem { get; set; }
        public DbSet<RateSchedule> RateSchedule { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Quotation>().ToTable("Quotation");
            modelBuilder.Entity<QuotationRequest>().ToTable("QuotationRequest");
            modelBuilder.Entity<QuotationItem>().ToTable("QuotationItem");
            modelBuilder.Entity<RateSchedule>().ToTable("RateSchedule").HasData(
                new RateSchedule { Id = 1, ChargeType = "Warf Booking Fee", Rate20Ft = 60.0m, Rate40Ft = 70.0m },
                new RateSchedule { Id = 2, ChargeType = "Lift on/Lift Off", Rate20Ft = 80.0m, Rate40Ft = 120.0m },
                new RateSchedule { Id = 3, ChargeType = "Fumigation", Rate20Ft = 220.0m, Rate40Ft = 280.0m },
                new RateSchedule { Id = 4, ChargeType = "LCL Delivery Depot", Rate20Ft = 400.0m, Rate40Ft = 500.0m },
                new RateSchedule { Id = 5, ChargeType = "Tailgate Inspection", Rate20Ft = 120.0m, Rate40Ft = 160.0m },
                new RateSchedule { Id = 6, ChargeType = "Storage Fee", Rate20Ft = 240.0m, Rate40Ft = 300.0m },
                new RateSchedule { Id = 7, ChargeType = "Facility Fee", Rate20Ft = 70.0m, Rate40Ft = 100.0m },
                new RateSchedule { Id = 8, ChargeType = "Warf Inspection", Rate20Ft = 60.0m, Rate40Ft = 90.0m }
                );

            modelBuilder.Entity<Quotation>()
           .HasOne(q => q.QuotationRequest)
           .WithMany(qr => qr.Quotations)
           .HasForeignKey(q => q.QuotationRequestId)
           .OnDelete(DeleteBehavior.Cascade);

        }

        
    }



    
}
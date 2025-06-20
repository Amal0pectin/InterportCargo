﻿// <auto-generated />
using System;
using Interport_Amal.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Interport_Amal.Migrations
{
    [DbContext(typeof(CargoDBContext))]
    [Migration("20250606120541_SeedRateSchedule")]
    partial class SeedRateSchedule
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.5");

            modelBuilder.Entity("Interport_Amal.BusinessLogic.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Phone")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("Interport_Amal.BusinessLogic.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployeeType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Phone")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("Interport_Amal.BusinessLogic.Entities.Quotation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContainerType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateIssued")
                        .HasColumnType("TEXT");

                    b.Property<string>("QuotationNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ScopeDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalCharge")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Quotation");
                });

            modelBuilder.Entity("Interport_Amal.BusinessLogic.Entities.QuotationItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuotationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RateScheduleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("QuotationId");

                    b.HasIndex("RateScheduleId");

                    b.ToTable("QuotationItem");
                });

            modelBuilder.Entity("Interport_Amal.BusinessLogic.Entities.RateSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContainerType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Rate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServiceType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RateSchedule", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContainerType = "20 Feet Container",
                            Rate = 60.0m,
                            ServiceType = "Walf Booking fee"
                        },
                        new
                        {
                            Id = 2,
                            ContainerType = "40 Feet Container",
                            Rate = 70.0m,
                            ServiceType = "Walf Booking fee"
                        },
                        new
                        {
                            Id = 3,
                            ContainerType = "20 Feet Container",
                            Rate = 80.0m,
                            ServiceType = "Lift on/Lif Off"
                        },
                        new
                        {
                            Id = 4,
                            ContainerType = "40 Feet Container",
                            Rate = 120.0m,
                            ServiceType = "Lift on/Lif Off"
                        },
                        new
                        {
                            Id = 5,
                            ContainerType = "20 Feet Container",
                            Rate = 220.0m,
                            ServiceType = "Fumigation"
                        },
                        new
                        {
                            Id = 6,
                            ContainerType = "40 Feet Container",
                            Rate = 280.0m,
                            ServiceType = "Fumigation"
                        },
                        new
                        {
                            Id = 7,
                            ContainerType = "20 Feet Container",
                            Rate = 400.0m,
                            ServiceType = "LCL Delivery Depot"
                        },
                        new
                        {
                            Id = 8,
                            ContainerType = "40 Feet Container",
                            Rate = 500.0m,
                            ServiceType = "LCL Delivery Depot"
                        },
                        new
                        {
                            Id = 9,
                            ContainerType = "20 Feet Container",
                            Rate = 120.0m,
                            ServiceType = "Tailgate Inspection"
                        },
                        new
                        {
                            Id = 10,
                            ContainerType = "40 Feet Container",
                            Rate = 160.0m,
                            ServiceType = "Tailgate Inspection"
                        },
                        new
                        {
                            Id = 11,
                            ContainerType = "20 Feet Container",
                            Rate = 240.0m,
                            ServiceType = "Storage Fee"
                        },
                        new
                        {
                            Id = 12,
                            ContainerType = "40 Feet Container",
                            Rate = 300.0m,
                            ServiceType = "Storage Fee"
                        },
                        new
                        {
                            Id = 13,
                            ContainerType = "20 Feet Container",
                            Rate = 70.0m,
                            ServiceType = "Facility Fee"
                        },
                        new
                        {
                            Id = 14,
                            ContainerType = "40 Feet Container",
                            Rate = 100.0m,
                            ServiceType = "Facility Fee"
                        },
                        new
                        {
                            Id = 15,
                            ContainerType = "20 Feet Container",
                            Rate = 60.0m,
                            ServiceType = "Warf Inspection"
                        },
                        new
                        {
                            Id = 16,
                            ContainerType = "40 Feet Container",
                            Rate = 90.0m,
                            ServiceType = "Warf Inspection"
                        });
                });

            modelBuilder.Entity("Interport_Amal.BusinessLogic.Entities.Quotation", b =>
                {
                    b.HasOne("Interport_Amal.BusinessLogic.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Interport_Amal.BusinessLogic.Entities.QuotationItem", b =>
                {
                    b.HasOne("Interport_Amal.BusinessLogic.Entities.Quotation", "Quotation")
                        .WithMany("Items")
                        .HasForeignKey("QuotationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Interport_Amal.BusinessLogic.Entities.RateSchedule", "RateSchedule")
                        .WithMany("QuotationItems")
                        .HasForeignKey("RateScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quotation");

                    b.Navigation("RateSchedule");
                });

            modelBuilder.Entity("Interport_Amal.BusinessLogic.Entities.Quotation", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Interport_Amal.BusinessLogic.Entities.RateSchedule", b =>
                {
                    b.Navigation("QuotationItems");
                });
#pragma warning restore 612, 618
        }
    }
}

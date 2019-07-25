﻿// <auto-generated />
using System;
using EMS.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EMS.Website.Migrations.ProjectDb
{
    [DbContext(typeof(ProjectDbContext))]
    [Migration("20190725073001_EmployeeIdRemoved")]
    partial class EmployeeIdRemoved
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EMS.Entity.Entities.ApprovalInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApprovedBy");

                    b.Property<DateTime>("ApprovedDate");

                    b.Property<string>("Comment");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsApproved");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<double>("TotalExpenses");

                    b.Property<int>("TravelID");

                    b.HasKey("ID");

                    b.HasIndex("TravelID")
                        .IsUnique();

                    b.ToTable("ApprovalInfo");
                });

            modelBuilder.Entity("EMS.Entity.Entities.EmployeeInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.HasKey("ID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("EMS.Entity.Entities.EntertainmentFB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("Date");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<double>("Price");

                    b.HasKey("ID");

                    b.ToTable("EntertainmentFB");
                });

            modelBuilder.Entity("EMS.Entity.Entities.MiscExpenses", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("Date");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<double>("Price");

                    b.HasKey("ID");

                    b.ToTable("MiscExpenses");
                });

            modelBuilder.Entity("EMS.Entity.Entities.MstExpenses", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("Order");

                    b.HasKey("ID");

                    b.ToTable("MstExpenses");
                });

            modelBuilder.Entity("EMS.Entity.Entities.TravelExpenses", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Details");

                    b.Property<double>("Expenses");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("TravelID");

                    b.HasKey("ID");

                    b.HasIndex("TravelID");

                    b.ToTable("TravelExpenses");
                });

            modelBuilder.Entity("EMS.Entity.Entities.TravelInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankName");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Currency");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Department");

                    b.Property<string>("Destination");

                    b.Property<string>("EmployeeFName")
                        .IsRequired();

                    b.Property<string>("EmployeeLName");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("IBAN");

                    b.Property<bool?>("IsApproved");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Purpose");

                    b.Property<string>("RecieptDoc");

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("ID");

                    b.ToTable("TravelInfo");
                });

            modelBuilder.Entity("EMS.Entity.Entities.ApprovalInfo", b =>
                {
                    b.HasOne("EMS.Entity.Entities.TravelInfo", "TravelInfo")
                        .WithOne("ApprovalInfo")
                        .HasForeignKey("EMS.Entity.Entities.ApprovalInfo", "TravelID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EMS.Entity.Entities.TravelExpenses", b =>
                {
                    b.HasOne("EMS.Entity.Entities.TravelInfo", "TravelInfo")
                        .WithMany("TravelExpenses")
                        .HasForeignKey("TravelID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
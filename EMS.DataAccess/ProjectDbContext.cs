using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using EMS.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace EMS.DataAccess
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions options) : base(options)
        {

        }

      
        public DbSet<MstExpenses> MstExpenses { get; set; }
        public DbSet<TravelInfo> TravelInfo { get; set; }
        public DbSet<MiscExpenses> MiscExpenses { get; set; }
        public DbSet<TravelExpenses> TravelExpenses { get; set; }
  
        public DbSet<ApprovalInfo> ApprovalInfo { get; set; }
        public DbSet<EntertainmentFB> EntertainmentFB { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            builder.Entity<TravelInfo>()
                 .HasOne(a => a.ApprovalInfo).WithOne(b => b.TravelInfo)
                .HasForeignKey<ApprovalInfo>(e => e.TravelID);

            builder.Entity<TravelExpenses>()
                 .HasOne(e => e.TravelInfo)
                 .WithMany(c => c.TravelExpenses).HasForeignKey(e=>e.TravelID);

            builder.Entity<MiscExpenses>()
                 .HasOne(e => e.TravelExpenses)
                 .WithMany(c => c.MiscExpenses).HasForeignKey(e => e.TraveExpID);


            base.OnModelCreating(builder);
       
        }
    }

   

    }


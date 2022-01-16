using GoogleOAuth.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleOAuth.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<User> Details { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.Entity<User>().ToTable("User");


            //Products
            //modelBuilder.Entity<DetailsData>.ToTable("Details");
            //modelBuilder.Entity<DepartmentData>.ToTable("Departments");

            // Configure Primary Keys  
            modelBuilder.Entity<User>().HasKey(ug => ug.Id).HasName("PK_UserId");

            //Primary Keys
            //modelBuilder.Entity<DepartmentData>().HasKey(ug => ug.DeptId).HasName("PK_DeptId");



            modelBuilder.Entity<User>().Property(ug => ug.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<User>().Property(ug => ug.Name).HasColumnType("nvarchar(100)").IsRequired(false);
            modelBuilder.Entity<User>().Property(ug => ug.Password).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            //modelBuilder.Entity<UserGroup>().Property(ug => ug.LastUpdateDateTime).HasColumnType("datetime").IsRequired(false);
        }
    }
}

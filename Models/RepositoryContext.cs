using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PhonesBook.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesBook.Models
{
    public class RepositoryContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        //public readonly IConfiguration Configuration;

        //public RepositoryContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("DefaultConnection");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.userID);

            modelBuilder.Entity<User>()
                .Property(u => u.firstName)
                .HasColumnName("firstName");

            modelBuilder.Entity<User>()
                .Property(u => u.secondName)
                .HasColumnName("secondName");

            modelBuilder.Entity<User>()
                .Property(u => u.isAdmin)
                .HasColumnName("isAdmin");

            modelBuilder.Entity<Contact>()
                .HasKey(u => u.contactID);

            modelBuilder.Entity<Contact>()
                .Property(u => u.contactName)
                .HasColumnName("contactName");

            modelBuilder.Entity<Contact>()
                .Property(u => u.phoneNumber)
                .HasColumnName("phoneNumber");

            modelBuilder.Entity<Contact>()
                .Property(u => u.countryName)
                .HasColumnName("countryName");

            base.OnModelCreating(modelBuilder);
        }

        //public class DesignTimeActivitiesDbContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
        //{
        //    public RepositoryContext CreateDbContext(string[] args)
        //    {
        //        var builder = new ConfigurationBuilder()
        //            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
        //            .AddJsonFile("appsettings.Development.json", optional: false);

        //        var config = builder.Build();

        //        var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>()
        //            .UseSqlServer(config.GetConnectionString("DefaultConnection"));

        //        return new RepositoryContext(optionsBuilder.Options);
        //    }
        //}
    }
}

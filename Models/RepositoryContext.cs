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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .HasColumnName("firstName");

            modelBuilder.Entity<User>()
                .Property(u => u.SecondName)
                .HasColumnName("secondName");

            modelBuilder.Entity<User>()
                .Property(u => u.IsAdmin)
                .HasColumnName("isAdmin");

            modelBuilder.Entity<Contact>()
                .HasKey(u => u.ContactId);

            modelBuilder.Entity<Contact>()
                .Property(u => u.ContactName)
                .HasColumnName("contactName");

            modelBuilder.Entity<Contact>()
                .Property(u => u.PhoneNumber)
                .HasColumnName("phoneNumber");

            modelBuilder.Entity<Contact>()
                .Property(u => u.CountryName)
                .HasColumnName("countryName");
            modelBuilder.Entity<Contact>()
                .Property(u => u.UserId)
                .HasColumnName("userId");

            base.OnModelCreating(modelBuilder);
        }
    }
}

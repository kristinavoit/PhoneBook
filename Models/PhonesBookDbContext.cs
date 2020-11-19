using Microsoft.EntityFrameworkCore;
using PhonesBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesBook.Models
{
    public class PhonesBookDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        //public PhonesBookDbContext(DbContextOptions<PhonesBookDbContext> options) : base(options)
        //{ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=VOITPC;Database=DBPhonesBook;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.userID);

            modelBuilder.Entity<User>()
                .Property(u => u.userName)
                .HasColumnName("userName");

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

            base.OnModelCreating(modelBuilder);
        }

        interface IRepository<T> : IDisposable
        where T : class
        {
            IEnumerable<T> GetContacts();
            T GetContact(int id);
            void Create(T item);
            void Update(T item);
            void Save();
            void Delete(int id);

        }
    }
}

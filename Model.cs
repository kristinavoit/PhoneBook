using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PhonesBook
{
    public class UserContext: System.Data.Entity.DbContext
    {
        public UserContext() : base("DefaultConnection")
        {}
        public System.Data.Entity.DbSet<User> Users { get; set; }
        public System.Data.Entity.DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(u => u.userID);
            modelBuilder.Entity<User>().Property(u => u.userName).HasColumnName("userName");
            modelBuilder.Entity<User>().Property(u => u.isAdmin).HasColumnName("isAdmin");


            modelBuilder.Entity<Contact>().ToTable("Contacts");
            modelBuilder.Entity<Contact>().HasKey(u => u.contactID);
            modelBuilder.Entity<Contact>().Property(u => u.contactName).HasColumnName("contactName");
            modelBuilder.Entity<Contact>().Property(u => u.phoneNumber).HasColumnName("phoneNumber");

            base.OnModelCreating(modelBuilder);
        }
    }

    public class User
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public bool isAdmin { get; set; }
    }

    public class Contact
    {
        public int contactID { get; set; }
        public string contactName { get; set; }
        public string phoneNumber { get; set; }
    }


    interface IRepository <T> : IDisposable
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

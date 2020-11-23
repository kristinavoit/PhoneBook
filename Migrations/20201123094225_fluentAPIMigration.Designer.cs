﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhonesBook.Models;

namespace PhonesBook.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20201123094225_fluentAPIMigration")]
    partial class fluentAPIMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("PhonesBook.Models.Contact", b =>
                {
                    b.Property<int>("contactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("contactName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contactName");

                    b.Property<string>("countryName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("countryName");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phoneNumber");

                    b.HasKey("contactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("PhonesBook.Models.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("firstName");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit")
                        .HasColumnName("isAdmin");

                    b.Property<string>("secondName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("secondName");

                    b.HasKey("userID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

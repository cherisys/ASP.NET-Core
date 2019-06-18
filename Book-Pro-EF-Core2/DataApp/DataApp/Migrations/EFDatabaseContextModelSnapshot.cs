﻿// <auto-generated />
using System;
using DataApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataApp.Migrations
{
    [DbContext(typeof(EFDatabaseContext))]
    partial class EFDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataApp.Models.ContactDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("LocationId");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<long?>("SupplierId");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("SupplierId")
                        .IsUnique()
                        .HasFilter("[SupplierId] IS NOT NULL");

                    b.ToTable("ContactDetails");
                });

            modelBuilder.Entity("DataApp.Models.ContactLocation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("LocationName");

                    b.HasKey("Id");

                    b.ToTable("ContactLocation");
                });

            modelBuilder.Entity("DataApp.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<int>("Color");

                    b.Property<bool>("InStock");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("SupplierId");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DataApp.Models.ProductShipmentJunction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ProductId");

                    b.Property<long>("ShipmentId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShipmentId");

                    b.ToTable("ProductShipmentJunction");
                });

            modelBuilder.Entity("DataApp.Models.Shipment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EndCity");

                    b.Property<string>("ShipperName");

                    b.Property<string>("StartCity");

                    b.HasKey("Id");

                    b.ToTable("Shipment");
                });

            modelBuilder.Entity("DataApp.Models.Supplier", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("DataApp.Models.ContactDetails", b =>
                {
                    b.HasOne("DataApp.Models.ContactLocation", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("DataApp.Models.Supplier", "Supplier")
                        .WithOne("Contact")
                        .HasForeignKey("DataApp.Models.ContactDetails", "SupplierId");
                });

            modelBuilder.Entity("DataApp.Models.Product", b =>
                {
                    b.HasOne("DataApp.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataApp.Models.ProductShipmentJunction", b =>
                {
                    b.HasOne("DataApp.Models.Product", "Product")
                        .WithMany("ProductShipments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataApp.Models.Shipment", "Shipment")
                        .WithMany("ProductShipments")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

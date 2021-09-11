﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodyProject.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20210911091641_duja2021")]
    partial class duja2021
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Entities.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Entities.Models.CustomerContact", b =>
                {
                    b.Property<int>("CustomerContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("CustomerContactId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerContacts");
                });

            modelBuilder.Entity("Entities.Models.Meal", b =>
                {
                    b.Property<int>("MealId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailabe")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MealOptions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("MealId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OrderId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("Entities.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DelieveredTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelivered")
                        .HasColumnType("bit");

                    b.Property<string>("OrderDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<string>("TypeOfPayment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Entities.Models.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("AvgDeliveryTime")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<float>("MinPrice")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasMaxLength(60)
                        .HasColumnType("bit");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("WorkingHours")
                        .HasColumnType("datetime2");

                    b.HasKey("RestaurantId");

                    b.ToTable("Resturants");
                });

            modelBuilder.Entity("Entities.Models.RestaurantContact", b =>
                {
                    b.Property<int>("RestaurantContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("RestaurantContactId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantContacts");
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.HasOne("Entities.Models.Restaurant", "Restaurants")
                        .WithMany("Categories")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("Entities.Models.CustomerContact", b =>
                {
                    b.HasOne("Entities.Models.Customer", "Customer")
                        .WithMany("CustomerContacts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Entities.Models.Meal", b =>
                {
                    b.HasOne("Entities.Models.Category", "Category")
                        .WithMany("Meals")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Order", null)
                        .WithMany("Meals")
                        .HasForeignKey("OrderId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entities.Models.Order", b =>
                {
                    b.HasOne("Entities.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Restaurant", "Restaurants")
                        .WithMany("Orders")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("Entities.Models.RestaurantContact", b =>
                {
                    b.HasOne("Entities.Models.Restaurant", "Restaurant")
                        .WithMany("RestaurantContacts")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Navigation("Meals");
                });

            modelBuilder.Entity("Entities.Models.Customer", b =>
                {
                    b.Navigation("CustomerContacts");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Entities.Models.Order", b =>
                {
                    b.Navigation("Meals");
                });

            modelBuilder.Entity("Entities.Models.Restaurant", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Orders");

                    b.Navigation("RestaurantContacts");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using FastFood.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FastFood.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FastFood.Data.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CImageUrl");

                    b.Property<string>("CategoryName");

                    b.Property<string>("Description");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FastFood.Data.Models.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("ImageThumbnailUrl");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("InStock");

                    b.Property<bool>("IsPreferredDrink");

                    b.Property<string>("LongDescription");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<string>("ShortDescription");

                    b.HasKey("FoodId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("FastFood.Data.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("AddressLine2");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("OrderPlaced");

                    b.Property<decimal>("OrderTotal");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("State")
                        .HasMaxLength(10);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FastFood.Data.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int>("FoodId");

                    b.Property<int>("OrderId");

                    b.Property<decimal>("Price");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("FoodId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("FastFood.Data.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int?>("FoodId");

                    b.Property<string>("ShoppingCartId");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("FoodId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("FastFood.Data.Models.Food", b =>
                {
                    b.HasOne("FastFood.Data.Models.Category", "Category")
                        .WithMany("Foods")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FastFood.Data.Models.OrderDetail", b =>
                {
                    b.HasOne("FastFood.Data.Models.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FastFood.Data.Models.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FastFood.Data.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("FastFood.Data.Models.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Infra.Persestent.Ef;

#nullable disable

namespace Shop.Infra.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20250321074156_initssssss")]
    partial class initssssss
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shop.Domain.ProductsAgg.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("BestSelling")
                        .HasColumnType("bit");

                    b.Property<int>("BuildQuality")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Design")
                        .HasColumnType("int");

                    b.Property<int>("Featured")
                        .HasColumnType("int");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PurchaseValue")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalRate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products", "Product");
                });

            modelBuilder.Entity("Shop.Domain.UserAgg.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("BankCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", "User");
                });

            modelBuilder.Entity("Shop.Domain.ProductsAgg.Product", b =>
                {
                    b.OwnsMany("Shop.Domain.ProductsAgg.Comment", "Comments", b1 =>
                        {
                            b1.Property<long>("ProductId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"));

                            b1.Property<DateTime>("CreateAt")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("CreationDate")
                                .HasColumnType("datetime2");

                            b1.Property<int>("Rate")
                                .HasColumnType("int");

                            b1.Property<string>("UserComment")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("UserName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ProductId", "Id");

                            b1.ToTable("Comments", "Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsMany("Shop.Domain.ProductsAgg.Faq", "Faqs", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"));

                            b1.Property<DateTime>("CreationDate")
                                .HasColumnType("datetime2");

                            b1.Property<long>("ProductId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Question")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("UserName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id");

                            b1.HasIndex("ProductId");

                            b1.ToTable("Faqs", "Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");

                            b1.OwnsMany("Shop.Domain.ProductsAgg.Answer", "Answer", b2 =>
                                {
                                    b2.Property<long>("AnswerId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("bigint");

                                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b2.Property<long>("AnswerId"));

                                    b2.Property<string>("AnswerFaq")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<long>("FaqId")
                                        .HasColumnType("bigint");

                                    b2.HasKey("AnswerId");

                                    b2.HasIndex("FaqId");

                                    b2.ToTable("Answers", "Faq");

                                    b2.WithOwner("Faq")
                                        .HasForeignKey("FaqId");

                                    b2.Navigation("Faq");
                                });

                            b1.Navigation("Answer");
                        });

                    b.OwnsMany("Shop.Domain.ProductsAgg.ProductIImage", "Images", b1 =>
                        {
                            b1.Property<long>("ProductId")
                                .HasColumnType("bigint");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Image")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ProductId", "Id");

                            b1.ToTable("Images", "Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("Shop.Domain.ProductsAgg.ValueObjects.Discount", "ProductDiscount", b1 =>
                        {
                            b1.Property<long>("ProductId")
                                .HasColumnType("bigint");

                            b1.Property<int>("Amount")
                                .HasColumnType("int");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products", "Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("Shop.Domain.ProductsAgg.ValueObjects.Price", "ProductPrice", b1 =>
                        {
                            b1.Property<long>("ProductId")
                                .HasColumnType("bigint");

                            b1.Property<int>("Value")
                                .HasColumnType("int");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products", "Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Comments");

                    b.Navigation("Faqs");

                    b.Navigation("Images");

                    b.Navigation("ProductDiscount")
                        .IsRequired();

                    b.Navigation("ProductPrice")
                        .IsRequired();
                });

            modelBuilder.Entity("Shop.Domain.UserAgg.User", b =>
                {
                    b.OwnsMany("Shop.Domain.UserAgg.UserAddress", "Addresses", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"));

                            b1.Property<DateTime>("CreationDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("ReceiverCity")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ReceiverName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ReceiverPhone")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ReceiverPostalAddress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ReceiverPostalCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ReceiverProvince")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId", "Id");

                            b1.ToTable("Addresses", "User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}

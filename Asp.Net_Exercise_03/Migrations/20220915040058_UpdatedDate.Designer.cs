﻿// <auto-generated />
using System;
using Asp.Net_Exercise_03.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Asp.Net_Exercise_03.Migrations
{
    [DbContext(typeof(PartyDbContext))]
    [Migration("20220915040058_UpdatedDate")]
    partial class UpdatedDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Asp.Net_Exercise_03.DataBase.AssignParty", b =>
                {
                    b.Property<int>("Assign_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Party_id")
                        .HasColumnType("int");

                    b.Property<int>("Product_id")
                        .HasColumnType("int");

                    b.HasKey("Assign_id");

                    b.HasIndex("Party_id");

                    b.HasIndex("Product_id");

                    b.ToTable("Assign_party_tbl");
                });

            modelBuilder.Entity("Asp.Net_Exercise_03.DataBase.Party", b =>
                {
                    b.Property<int>("Party_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Party_name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Party_id");

                    b.HasIndex("Party_name")
                        .IsUnique()
                        .HasFilter("[Party_name] IS NOT NULL");

                    b.ToTable("Party_tbl");
                });

            modelBuilder.Entity("Asp.Net_Exercise_03.DataBase.Product", b =>
                {
                    b.Property<int>("Product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Product_name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Product_id");

                    b.HasIndex("Product_name")
                        .IsUnique()
                        .HasFilter("[Product_name] IS NOT NULL");

                    b.ToTable("Product_tbl");
                });

            modelBuilder.Entity("Asp.Net_Exercise_03.DataBase.ProductRate", b =>
                {
                    b.Property<int>("Rate_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date_of_Rate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Product_id")
                        .HasColumnType("int");

                    b.Property<int>("Product_rate")
                        .HasColumnType("int");

                    b.HasKey("Rate_id");

                    b.HasIndex("Product_id");

                    b.ToTable("Rate_tbl");
                });

            modelBuilder.Entity("Asp.Net_Exercise_03.DataBase.AssignParty", b =>
                {
                    b.HasOne("Asp.Net_Exercise_03.DataBase.Party", "Party_tbl")
                        .WithMany()
                        .HasForeignKey("Party_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp.Net_Exercise_03.DataBase.Product", "Product_tbl")
                        .WithMany()
                        .HasForeignKey("Product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Asp.Net_Exercise_03.DataBase.ProductRate", b =>
                {
                    b.HasOne("Asp.Net_Exercise_03.DataBase.Product", "Product_tbl")
                        .WithMany()
                        .HasForeignKey("Product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Beads_Store.Data;

namespace Beads_Store.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20211015174453_AddOrder")]
    partial class AddOrder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Musical_Instrument_Store.Data.Models.CartLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CartId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("musicalInstrumentId")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("musicalInstrumentId");

                    b.ToTable("cartLines");
                });

            modelBuilder.Entity("Musical_Instrument_Store.Data.Models.MICategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("categoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("mICategories");
                });

            modelBuilder.Entity("Musical_Instrument_Store.Data.Models.MusicalInstrument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MICategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("available")
                        .HasColumnType("bit");

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<string>("descMI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameMI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MICategoryId");

                    b.ToTable("MusicalInstruments");
                });

            modelBuilder.Entity("Musical_Instrument_Store.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("addressClient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emailClient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nameClient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("orderTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("phoneClient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surnameClient")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("Musical_Instrument_Store.Data.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("miId")
                        .HasColumnType("int");

                    b.Property<int?>("musicalInstrumentId")
                        .HasColumnType("int");

                    b.Property<int>("orderId")
                        .HasColumnType("int");

                    b.Property<long>("price")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("musicalInstrumentId");

                    b.HasIndex("orderId");

                    b.ToTable("orderDetails");
                });

            modelBuilder.Entity("Musical_Instrument_Store.Data.Models.CartLine", b =>
                {
                    b.HasOne("Musical_Instrument_Store.Data.Models.MusicalInstrument", "musicalInstrument")
                        .WithMany()
                        .HasForeignKey("musicalInstrumentId");

                    b.Navigation("musicalInstrument");
                });

            modelBuilder.Entity("Musical_Instrument_Store.Data.Models.MusicalInstrument", b =>
                {
                    b.HasOne("Musical_Instrument_Store.Data.Models.MICategory", "MICategory")
                        .WithMany("musicalInstruments")
                        .HasForeignKey("MICategoryId");

                    b.Navigation("MICategory");
                });

            modelBuilder.Entity("Musical_Instrument_Store.Data.Models.OrderDetail", b =>
                {
                    b.HasOne("Musical_Instrument_Store.Data.Models.MusicalInstrument", "musicalInstrument")
                        .WithMany()
                        .HasForeignKey("musicalInstrumentId");

                    b.HasOne("Musical_Instrument_Store.Data.Models.Order", "order")
                        .WithMany("orderDetails")
                        .HasForeignKey("orderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("musicalInstrument");

                    b.Navigation("order");
                });

            modelBuilder.Entity("Musical_Instrument_Store.Data.Models.MICategory", b =>
                {
                    b.Navigation("musicalInstruments");
                });

            modelBuilder.Entity("Musical_Instrument_Store.Data.Models.Order", b =>
                {
                    b.Navigation("orderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using AdvertisingApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdvertisingApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240717121356_AddCreationDateToAdvertisement")]
    partial class AddCreationDateToAdvertisement
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdvertisingApi.Models.Advertisement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("AdvertisingApi.Models.PhotoUrl", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdvertisementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementId");

                    b.ToTable("PhotoUrls");
                });

            modelBuilder.Entity("AdvertisingApi.Models.PhotoUrl", b =>
                {
                    b.HasOne("AdvertisingApi.Models.Advertisement", "Advertisement")
                        .WithMany("PhotoUrls")
                        .HasForeignKey("AdvertisementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Advertisement");
                });

            modelBuilder.Entity("AdvertisingApi.Models.Advertisement", b =>
                {
                    b.Navigation("PhotoUrls");
                });
#pragma warning restore 612, 618
        }
    }
}

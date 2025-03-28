﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ServiceC.Web.Contexts;

#nullable disable

namespace ServiceC.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250318235824_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ServiceC.Web.Entities.WeatherRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("DewPoint")
                        .HasColumnType("double precision");

                    b.Property<double>("FeelsLike")
                        .HasColumnType("double precision");

                    b.Property<int>("Humidity")
                        .HasColumnType("integer");

                    b.Property<double>("Pressure")
                        .HasColumnType("double precision");

                    b.Property<double>("TemperatureC")
                        .HasColumnType("double precision");

                    b.Property<double>("WindSpeed")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("WeatherRecords");
                });
#pragma warning restore 612, 618
        }
    }
}

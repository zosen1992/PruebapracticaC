﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaC_API.Datos;

#nullable disable

namespace PruebaC_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PruebaC_API.Modelos.Prueba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Distancia")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fechacreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocupantes")
                        .HasColumnType("int");

                    b.Property<double>("Tarifa")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Pruebas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenidad = "",
                            Detalle = "Algun detalle",
                            Distancia = 10,
                            FechaActualizacion = new DateTime(2023, 8, 8, 13, 50, 58, 722, DateTimeKind.Local).AddTicks(1892),
                            Fechacreacion = new DateTime(2023, 8, 8, 13, 50, 58, 722, DateTimeKind.Local).AddTicks(1883),
                            ImagenUrl = "",
                            Nombre = "Algun Nombre",
                            Ocupantes = 5,
                            Tarifa = 100.0
                        },
                        new
                        {
                            Id = 2,
                            Amenidad = "",
                            Detalle = "Algun detalle",
                            Distancia = 10,
                            FechaActualizacion = new DateTime(2023, 8, 8, 13, 50, 58, 722, DateTimeKind.Local).AddTicks(1895),
                            Fechacreacion = new DateTime(2023, 8, 8, 13, 50, 58, 722, DateTimeKind.Local).AddTicks(1895),
                            ImagenUrl = "",
                            Nombre = "Algun Nombre",
                            Ocupantes = 5,
                            Tarifa = 100.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

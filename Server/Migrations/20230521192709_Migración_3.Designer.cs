﻿// <auto-generated />
using System;
using BlazorApp_Act17.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorApp_Act17.Server.Migrations
{
    [DbContext(typeof(BDProveedoresContext))]
    [Migration("20230521192709_Migración_3")]
    partial class Migración_3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorApp_Act17.Shared.Clases.Productos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cantidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ProveedoresId")
                        .HasColumnType("int");

                    b.Property<int?>("VentasId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProveedoresId");

                    b.HasIndex("VentasId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("BlazorApp_Act17.Shared.Clases.Proveedores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Dirección")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("BlazorApp_Act17.Shared.Clases.Ventas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad_Vendida")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Precio_Venta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("BlazorApp_Act17.Shared.Clases.Productos", b =>
                {
                    b.HasOne("BlazorApp_Act17.Shared.Clases.Proveedores", "Proveedores")
                        .WithMany("Productos")
                        .HasForeignKey("ProveedoresId");

                    b.HasOne("BlazorApp_Act17.Shared.Clases.Ventas", null)
                        .WithMany("Productos")
                        .HasForeignKey("VentasId");

                    b.Navigation("Proveedores");
                });

            modelBuilder.Entity("BlazorApp_Act17.Shared.Clases.Proveedores", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("BlazorApp_Act17.Shared.Clases.Ventas", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}

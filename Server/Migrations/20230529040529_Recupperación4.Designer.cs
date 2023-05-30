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
    [Migration("20230529040529_Recupperación4")]
    partial class Recupperación4
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

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ProveedoresId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProveedoresId");

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

            modelBuilder.Entity("ProductosVentas", b =>
                {
                    b.Property<int>("ProductosId")
                        .HasColumnType("int");

                    b.Property<int>("VentasId")
                        .HasColumnType("int");

                    b.HasKey("ProductosId", "VentasId");

                    b.HasIndex("VentasId");

                    b.ToTable("ProductosVentas");
                });

            modelBuilder.Entity("BlazorApp_Act17.Shared.Clases.Productos", b =>
                {
                    b.HasOne("BlazorApp_Act17.Shared.Clases.Proveedores", "Proveedor")
                        .WithMany("Producto")
                        .HasForeignKey("ProveedoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("ProductosVentas", b =>
                {
                    b.HasOne("BlazorApp_Act17.Shared.Clases.Productos", null)
                        .WithMany()
                        .HasForeignKey("ProductosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorApp_Act17.Shared.Clases.Ventas", null)
                        .WithMany()
                        .HasForeignKey("VentasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlazorApp_Act17.Shared.Clases.Proveedores", b =>
                {
                    b.Navigation("Producto");
                });
#pragma warning restore 612, 618
        }
    }
}

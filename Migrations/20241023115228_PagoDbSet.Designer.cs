﻿// <auto-generated />
using System;
using GestionPedidosAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionPedidosAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241023115228_PagoDbSet")]
    partial class PagoDbSet
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionPedidosAPI.Data.Articulo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PrecioSinIva")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Referencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("Stock")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("GestionPedidosAPI.Data.Cliente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NombreComercial")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Poblacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("ID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("GestionPedidosAPI.Data.LineaPedido", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<bool>("DosCaras")
                        .HasColumnType("bit");

                    b.Property<int>("IDArticulo")
                        .HasColumnType("int");

                    b.Property<int>("IDPedido")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modificado")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModificadoPorID")
                        .HasColumnType("int");

                    b.Property<string>("SituacionGrabacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Tinta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoGrabado")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IDArticulo");

                    b.HasIndex("IDPedido");

                    b.HasIndex("ModificadoPorID");

                    b.ToTable("LineasPedido");
                });

            modelBuilder.Entity("GestionPedidosAPI.Data.Pago", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CodigoSeguridad")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime>("FechaCaducidad")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombrePropietarioTarjeta")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NumeroTarjeta")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("ID");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("GestionPedidosAPI.Data.Pedido", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Creado")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreadoPorID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EntregaMax")
                        .HasColumnType("datetime2");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modificado")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModificadoPorID")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<string>("Vendedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.HasIndex("CreadoPorID");

                    b.HasIndex("IdCliente");

                    b.HasIndex("ModificadoPorID");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("GestionPedidosAPI.Data.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Taller")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GestionPedidosAPI.Data.LineaPedido", b =>
                {
                    b.HasOne("GestionPedidosAPI.Data.Articulo", "Articulo")
                        .WithMany()
                        .HasForeignKey("IDArticulo")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GestionPedidosAPI.Data.Pedido", "Pedido")
                        .WithMany("LineasPedido")
                        .HasForeignKey("IDPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionPedidosAPI.Data.Usuario", "ModificadoPor")
                        .WithMany()
                        .HasForeignKey("ModificadoPorID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Articulo");

                    b.Navigation("ModificadoPor");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("GestionPedidosAPI.Data.Pedido", b =>
                {
                    b.HasOne("GestionPedidosAPI.Data.Usuario", "CreadoPor")
                        .WithMany()
                        .HasForeignKey("CreadoPorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionPedidosAPI.Data.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GestionPedidosAPI.Data.Usuario", "ModificadoPor")
                        .WithMany()
                        .HasForeignKey("ModificadoPorID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Cliente");

                    b.Navigation("CreadoPor");

                    b.Navigation("ModificadoPor");
                });

            modelBuilder.Entity("GestionPedidosAPI.Data.Pedido", b =>
                {
                    b.Navigation("LineasPedido");
                });
#pragma warning restore 612, 618
        }
    }
}

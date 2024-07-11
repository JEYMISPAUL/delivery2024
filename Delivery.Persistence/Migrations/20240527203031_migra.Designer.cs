﻿// <auto-generated />
using System;
using Delivery.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Delivery.Persistence.Migrations
{
    [DbContext(typeof(DeliveryDBContext))]
    [Migration("20240527203031_migra")]
    partial class migra
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Delivery.Domain.Food.CaracteristicaComida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Detalle")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("CaracteristicaComidas");
                });

            modelBuilder.Entity("Delivery.Domain.Food.Comida", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Categoria")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MenuDelDia")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Comidas");
                });

            modelBuilder.Entity("Delivery.Domain.Food.Comida_CaracteristicaMenu", b =>
                {
                    b.Property<int>("IdComida")
                        .HasColumnType("int");

                    b.Property<int>("IdCaracteristicaComida")
                        .HasColumnType("int");

                    b.HasKey("IdComida", "IdCaracteristicaComida");

                    b.HasIndex("IdCaracteristicaComida");

                    b.ToTable("Comida_CaracteristicasMenu");
                });

            modelBuilder.Entity("Delivery.Domain.Food.Comida_CaracteristicaPedido", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Contenido")
                        .HasColumnType("text");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IdPedido");

                    b.ToTable("Comida_CaracteristicasPedido");
                });

            modelBuilder.Entity("Delivery.Domain.Order.Direccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Detalle")
                        .HasColumnType("text");

                    b.Property<string>("Nombre_Calle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Direcciones");
                });

            modelBuilder.Entity("Delivery.Domain.Order.MetodoPago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CVV")
                        .HasColumnType("char(3)");

                    b.Property<string>("NombreTarjeta")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Numero")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fechaExpiracion")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MetodoPagos");
                });

            modelBuilder.Entity("Delivery.Domain.Order.Pedido", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Detalle")
                        .HasColumnType("text");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_Fin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Inicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdDireccion")
                        .HasColumnType("int");

                    b.Property<int?>("IdMetodoPago")
                        .HasColumnType("int");

                    b.Property<int?>("IdRepartidor")
                        .HasColumnType("int");

                    b.Property<string>("Repartidor")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)");

                    b.Property<float?>("Total")
                        .HasColumnType("real");

                    b.HasKey("Codigo");

                    b.HasIndex("IdDireccion")
                        .IsUnique();

                    b.HasIndex("IdMetodoPago");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Delivery.Domain.User.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ComidaID")
                        .HasColumnType("int");

                    b.Property<string>("Contenido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComidaID");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("Delivery.Domain.User.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Bloqueado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Delivery.Domain.Food.Comida_CaracteristicaMenu", b =>
                {
                    b.HasOne("Delivery.Domain.Food.CaracteristicaComida", "CaracteristicaComida")
                        .WithMany("comida_CaracteristicasMenu")
                        .HasForeignKey("IdCaracteristicaComida")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Delivery.Domain.Food.Comida", "Comida")
                        .WithMany("comida_CaracteristicasMenu")
                        .HasForeignKey("IdComida")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CaracteristicaComida");

                    b.Navigation("Comida");
                });

            modelBuilder.Entity("Delivery.Domain.Food.Comida_CaracteristicaPedido", b =>
                {
                    b.HasOne("Delivery.Domain.Order.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Delivery.Domain.Order.Pedido", b =>
                {
                    b.HasOne("Delivery.Domain.Order.Direccion", "Direccion")
                        .WithOne("Pedido")
                        .HasForeignKey("Delivery.Domain.Order.Pedido", "IdDireccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Delivery.Domain.Order.MetodoPago", "MetodoPago")
                        .WithMany()
                        .HasForeignKey("IdMetodoPago");

                    b.Navigation("Direccion");

                    b.Navigation("MetodoPago");
                });

            modelBuilder.Entity("Delivery.Domain.User.Comentario", b =>
                {
                    b.HasOne("Delivery.Domain.Food.Comida", "Comida")
                        .WithMany()
                        .HasForeignKey("ComidaID");

                    b.HasOne("Delivery.Domain.User.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Comida");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Delivery.Domain.Food.CaracteristicaComida", b =>
                {
                    b.Navigation("comida_CaracteristicasMenu");
                });

            modelBuilder.Entity("Delivery.Domain.Food.Comida", b =>
                {
                    b.Navigation("comida_CaracteristicasMenu");
                });

            modelBuilder.Entity("Delivery.Domain.Order.Direccion", b =>
                {
                    b.Navigation("Pedido");
                });
#pragma warning restore 612, 618
        }
    }
}

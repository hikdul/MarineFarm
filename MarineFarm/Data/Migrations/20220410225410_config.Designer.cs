﻿// <auto-generated />
using System;
using MarineFarm.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarineFarm.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220410225410_config")]
    partial class config
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MarineFarm.Auth.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Userid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("rut")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("id");

                    b.HasIndex("Userid");

                    b.ToTable("AspNetUsuario");
                });

            modelBuilder.Entity("MarineFarm.Entitys.Almacen", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<double>("Cantidad")
                        .HasColumnType("float");

                    b.Property<int>("Productoid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Productoid");

                    b.ToTable("Almacen");
                });

            modelBuilder.Entity("MarineFarm.Entitys.Calibre", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("act")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("Calibres");
                });

            modelBuilder.Entity("MarineFarm.Entitys.Cargos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("CantOperadoresNecesario")
                        .HasColumnType("int");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("act")
                        .HasColumnType("bit");

                    b.Property<int>("sexo")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("MarineFarm.Entitys.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Desc")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("RUT")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("act")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("MarineFarm.Entitys.Configuraciones", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("DiasHabiles")
                        .HasColumnType("int");

                    b.Property<double>("KgBono")
                        .HasColumnType("float");

                    b.Property<double>("PagoBono")
                        .HasColumnType("float");

                    b.Property<double>("ProduccionDefaultPorDia")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("Config");
                });

            modelBuilder.Entity("MarineFarm.Entitys.Empaquetado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("act")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("Empaquetados");
                });

            modelBuilder.Entity("MarineFarm.Entitys.Equipo", b =>
                {
                    b.Property<int>("Turnoid")
                        .HasColumnType("int");

                    b.Property<int>("Cargoid")
                        .HasColumnType("int");

                    b.Property<int>("CantCubierta")
                        .HasColumnType("int");

                    b.Property<double>("CostoOperario")
                        .HasColumnType("float");

                    b.HasKey("Turnoid", "Cargoid");

                    b.HasIndex("Cargoid");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("MarineFarm.Entitys.HistorialMateriaPrima", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<double>("Cantidad")
                        .HasColumnType("float");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Ingreso")
                        .HasColumnType("bit");

                    b.Property<int>("Mariscoid")
                        .HasColumnType("int");

                    b.Property<int>("Usuarioid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Mariscoid");

                    b.HasIndex("Usuarioid");

                    b.ToTable("HistorialMateriaPrima");
                });

            modelBuilder.Entity("MarineFarm.Entitys.Marisco", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("act")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("Mariscos");
                });

            modelBuilder.Entity("MarineFarm.Entitys.MateriaPrima", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<double>("Cantidad")
                        .HasColumnType("float");

                    b.Property<int>("Mariscoid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Mariscoid");

                    b.ToTable("MateriasPrimas");
                });

            modelBuilder.Entity("MarineFarm.Entitys.MuestraDiaria", b =>
                {
                    b.Property<int>("ano")
                        .HasColumnType("int");

                    b.Property<int>("mes")
                        .HasColumnType("int");

                    b.Property<int>("Mariscoid")
                        .HasColumnType("int");

                    b.Property<int>("TipoProduccionid")
                        .HasColumnType("int");

                    b.Property<int>("Calibreid")
                        .HasColumnType("int");

                    b.Property<int>("Empaquetadoid")
                        .HasColumnType("int");

                    b.Property<double>("ProduccionDiaria")
                        .HasColumnType("float");

                    b.Property<double>("TotalProducido")
                        .HasColumnType("float");

                    b.HasKey("ano", "mes", "Mariscoid", "TipoProduccionid", "Calibreid", "Empaquetadoid");

                    b.HasIndex("Calibreid");

                    b.HasIndex("Empaquetadoid");

                    b.HasIndex("Mariscoid");

                    b.HasIndex("TipoProduccionid");

                    b.ToTable("MuestrasDiarias");
                });

            modelBuilder.Entity("MarineFarm.Entitys.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("Clienteid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEntregaPosible")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSolicitud")
                        .HasColumnType("datetime2");

                    b.Property<int>("Solicitanteid")
                        .HasColumnType("int");

                    b.Property<bool>("act")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("Clienteid");

                    b.HasIndex("Solicitanteid");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("MarineFarm.Entitys.PedidosProductos", b =>
                {
                    b.Property<int>("pedidoid")
                        .HasColumnType("int");

                    b.Property<int>("Productoid")
                        .HasColumnType("int");

                    b.Property<double>("Cantidad")
                        .HasColumnType("float");

                    b.HasKey("pedidoid", "Productoid");

                    b.HasIndex("Productoid");

                    b.ToTable("PP");
                });

            modelBuilder.Entity("MarineFarm.Entitys.PMariscoProduccion", b =>
                {
                    b.Property<int>("Produccionid")
                        .HasColumnType("int");

                    b.Property<int>("Mariscoid")
                        .HasColumnType("int");

                    b.Property<double>("CantidadUtilizada")
                        .HasColumnType("float");

                    b.HasKey("Produccionid", "Mariscoid");

                    b.HasIndex("Mariscoid");

                    b.ToTable("MariscoProduccion");
                });

            modelBuilder.Entity("MarineFarm.Entitys.PProductoProduccion", b =>
                {
                    b.Property<int>("Produccionid")
                        .HasColumnType("int");

                    b.Property<int>("Productoid")
                        .HasColumnType("int");

                    b.Property<double>("CantidadProducida")
                        .HasColumnType("float");

                    b.HasKey("Produccionid", "Productoid");

                    b.HasIndex("Productoid");

                    b.ToTable("ProductoProduccion");
                });

            modelBuilder.Entity("MarineFarm.Entitys.Produccion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Supervid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Supervid");

                    b.ToTable("Produccion");
                });

            modelBuilder.Entity("MarineFarm.Entitys.Producto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("Calibreid")
                        .HasColumnType("int");

                    b.Property<int>("Empaquetadoid")
                        .HasColumnType("int");

                    b.Property<int>("Mariscoid")
                        .HasColumnType("int");

                    b.Property<int>("TipoProduccionid")
                        .HasColumnType("int");

                    b.Property<bool>("act")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("Calibreid");

                    b.HasIndex("Empaquetadoid");

                    b.HasIndex("Mariscoid");

                    b.HasIndex("TipoProduccionid");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("MarineFarm.Entitys.TipoProduccion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("act")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("TiposProduccion");
                });

            modelBuilder.Entity("MarineFarm.Entitys.Turnos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("act")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MarineFarm.Auth.Usuario", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MarineFarm.Entitys.Almacen", b =>
                {
                    b.HasOne("MarineFarm.Entitys.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("Productoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("MarineFarm.Entitys.Equipo", b =>
                {
                    b.HasOne("MarineFarm.Entitys.Cargos", "Cargo")
                        .WithMany()
                        .HasForeignKey("Cargoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarineFarm.Entitys.Turnos", "Turno")
                        .WithMany()
                        .HasForeignKey("Turnoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Turno");
                });

            modelBuilder.Entity("MarineFarm.Entitys.HistorialMateriaPrima", b =>
                {
                    b.HasOne("MarineFarm.Entitys.Marisco", "Marisco")
                        .WithMany()
                        .HasForeignKey("Mariscoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarineFarm.Auth.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("Usuarioid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marisco");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MarineFarm.Entitys.MateriaPrima", b =>
                {
                    b.HasOne("MarineFarm.Entitys.Marisco", "Marisco")
                        .WithMany()
                        .HasForeignKey("Mariscoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marisco");
                });

            modelBuilder.Entity("MarineFarm.Entitys.MuestraDiaria", b =>
                {
                    b.HasOne("MarineFarm.Entitys.Calibre", "Calibre")
                        .WithMany()
                        .HasForeignKey("Calibreid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarineFarm.Entitys.Empaquetado", "Empaquetado")
                        .WithMany()
                        .HasForeignKey("Empaquetadoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarineFarm.Entitys.Marisco", "Marisco")
                        .WithMany()
                        .HasForeignKey("Mariscoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarineFarm.Entitys.TipoProduccion", "TipoProduccion")
                        .WithMany()
                        .HasForeignKey("TipoProduccionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calibre");

                    b.Navigation("Empaquetado");

                    b.Navigation("Marisco");

                    b.Navigation("TipoProduccion");
                });

            modelBuilder.Entity("MarineFarm.Entitys.Pedido", b =>
                {
                    b.HasOne("MarineFarm.Entitys.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("Clienteid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarineFarm.Auth.Usuario", "Solicitante")
                        .WithMany()
                        .HasForeignKey("Solicitanteid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Solicitante");
                });

            modelBuilder.Entity("MarineFarm.Entitys.PedidosProductos", b =>
                {
                    b.HasOne("MarineFarm.Entitys.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("Productoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarineFarm.Entitys.Pedido", "pedido")
                        .WithMany("PedidoProductos")
                        .HasForeignKey("pedidoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("pedido");
                });

            modelBuilder.Entity("MarineFarm.Entitys.PMariscoProduccion", b =>
                {
                    b.HasOne("MarineFarm.Entitys.Marisco", "Marisco")
                        .WithMany()
                        .HasForeignKey("Mariscoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarineFarm.Entitys.Produccion", "Produccion")
                        .WithMany("MariscosProduccion")
                        .HasForeignKey("Produccionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marisco");

                    b.Navigation("Produccion");
                });

            modelBuilder.Entity("MarineFarm.Entitys.PProductoProduccion", b =>
                {
                    b.HasOne("MarineFarm.Entitys.Produccion", "Produccion")
                        .WithMany("ProductoProduccion")
                        .HasForeignKey("Produccionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarineFarm.Entitys.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("Productoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produccion");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("MarineFarm.Entitys.Produccion", b =>
                {
                    b.HasOne("MarineFarm.Auth.Usuario", "Superv")
                        .WithMany()
                        .HasForeignKey("Supervid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Superv");
                });

            modelBuilder.Entity("MarineFarm.Entitys.Producto", b =>
                {
                    b.HasOne("MarineFarm.Entitys.Calibre", "Calibre")
                        .WithMany()
                        .HasForeignKey("Calibreid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarineFarm.Entitys.Empaquetado", "Empaquetado")
                        .WithMany()
                        .HasForeignKey("Empaquetadoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarineFarm.Entitys.Marisco", "Marisco")
                        .WithMany()
                        .HasForeignKey("Mariscoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarineFarm.Entitys.TipoProduccion", "TipoProduccion")
                        .WithMany()
                        .HasForeignKey("TipoProduccionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Calibre");

                    b.Navigation("Empaquetado");

                    b.Navigation("Marisco");

                    b.Navigation("TipoProduccion");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarineFarm.Entitys.Pedido", b =>
                {
                    b.Navigation("PedidoProductos");
                });

            modelBuilder.Entity("MarineFarm.Entitys.Produccion", b =>
                {
                    b.Navigation("MariscosProduccion");

                    b.Navigation("ProductoProduccion");
                });
#pragma warning restore 612, 618
        }
    }
}

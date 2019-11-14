﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebFarmacia.Web.Data;

namespace WebFarmacia.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191114120519_completeDB")]
    partial class completeDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebFarmacia.Web.Data.Entities.Medicinas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("OwnerId");

                    b.Property<string>("Precio")
                        .HasMaxLength(20);

                    b.Property<DateTime>("Publicacion");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("TipoMedicinasId");

                    b.Property<string>("imageUrl");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TipoMedicinasId");

                    b.ToTable("Medicinas");
                });

            modelBuilder.Entity("WebFarmacia.Web.Data.Entities.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FixedPhone")
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("WebFarmacia.Web.Data.Entities.TipoMedicinas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("TipoMedicinas");
                });

            modelBuilder.Entity("WebFarmacia.Web.Data.Entities.Medicinas", b =>
                {
                    b.HasOne("WebFarmacia.Web.Data.Entities.Owner", "Owner")
                        .WithMany("Medicinas")
                        .HasForeignKey("OwnerId");

                    b.HasOne("WebFarmacia.Web.Data.Entities.TipoMedicinas", "TipoMedicinas")
                        .WithMany("Medicinas")
                        .HasForeignKey("TipoMedicinasId");
                });
#pragma warning restore 612, 618
        }
    }
}
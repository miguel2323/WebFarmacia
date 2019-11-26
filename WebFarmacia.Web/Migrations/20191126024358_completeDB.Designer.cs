﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebFarmacia.Web.Data;

namespace WebFarmacia.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191126024358_completeDB")]
    partial class completeDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebFarmacia.Web.Data.Entities.Medicina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl");

                    b.Property<string>("IsAvailabe");

                    b.Property<string>("LastPurchase");

                    b.Property<string>("LastSale");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<double>("stock");

                    b.HasKey("Id");

                    b.ToTable("Medicinas");
                });
#pragma warning restore 612, 618
        }
    }
}
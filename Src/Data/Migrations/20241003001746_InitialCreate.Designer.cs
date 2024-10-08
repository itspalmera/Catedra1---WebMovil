﻿// <auto-generated />
using Catedra1___WebMovil.Src.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Catedra1___WebMovil.Src.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241003001746_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Catedra1___WebMovil.Src.Models.User", b =>
                {
                    b.Property<string>("Rut")
                        .HasColumnType("TEXT");

                    b.Property<int>("Date")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Rut");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoPrimerParcial.Data;

#nullable disable

namespace ProyectoPrimerParcial2.Migrations
{
    [DbContext(typeof(InstructorContext))]
    [Migration("20230522233735_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("ProyectoPrimerParcial.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DNI")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LegajoVuelo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NombreInstructor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructor");
                });
#pragma warning restore 612, 618
        }
    }
}
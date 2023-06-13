﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoPrimerParcial.Data;

#nullable disable

namespace Test.Migrations
{
    [DbContext(typeof(AeronaveContext))]
    [Migration("20230602065219_AddLegajoController")]
    partial class AddLegajoController
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("ProyectoPrimerParcial.Models.Aeronave", b =>
                {
                    b.Property<int>("AeronaveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaFabricacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoAeronave")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AeronaveId");

                    b.ToTable("Aeronave");
                });

            modelBuilder.Entity("ProyectoPrimerParcial.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AeronaveId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DNI")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EnActividad")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaExpedicion")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreInstructor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumeroLicencia")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoLicencia")
                        .HasColumnType("INTEGER");

                    b.HasKey("InstructorId");

                    b.HasIndex("AeronaveId");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("ProyectoPrimerParcial.Models.Instructor", b =>
                {
                    b.HasOne("ProyectoPrimerParcial.Models.Aeronave", "Aeronave")
                        .WithMany("InstructorList")
                        .HasForeignKey("AeronaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aeronave");
                });

            modelBuilder.Entity("ProyectoPrimerParcial.Models.Aeronave", b =>
                {
                    b.Navigation("InstructorList");
                });
#pragma warning restore 612, 618
        }
    }
}

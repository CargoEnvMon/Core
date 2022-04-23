﻿// <auto-generated />
using System;
using CargoEnvMon.Web.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CargoEnvMon.Web.Migrations
{
    [DbContext(typeof(CargoEnvMonDbContext))]
    [Migration("20220423194837_FixNull")]
    partial class FixNull
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CargoEnvMon.Web.DataLayer.Cargo", b =>
                {
                    b.Property<int>("CargoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CargoId"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ShipmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CargoId");

                    b.HasIndex("ShipmentId");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("CargoEnvMon.Web.DataLayer.Measurement", b =>
                {
                    b.Property<int>("MeasurementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MeasurementId"));

                    b.Property<int>("CargoId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float?>("Temperature")
                        .HasColumnType("real");

                    b.HasKey("MeasurementId");

                    b.HasIndex("CargoId");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("CargoEnvMon.Web.DataLayer.Shipment", b =>
                {
                    b.Property<int>("ShipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ShipmentId"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ShipmentId");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("CargoEnvMon.Web.DataLayer.Cargo", b =>
                {
                    b.HasOne("CargoEnvMon.Web.DataLayer.Shipment", "Shipment")
                        .WithMany("Cargos")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("CargoEnvMon.Web.DataLayer.Measurement", b =>
                {
                    b.HasOne("CargoEnvMon.Web.DataLayer.Cargo", "Cargo")
                        .WithMany("Measurements")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("CargoEnvMon.Web.DataLayer.Cargo", b =>
                {
                    b.Navigation("Measurements");
                });

            modelBuilder.Entity("CargoEnvMon.Web.DataLayer.Shipment", b =>
                {
                    b.Navigation("Cargos");
                });
#pragma warning restore 612, 618
        }
    }
}

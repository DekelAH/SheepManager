﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SheepManager.Infrastructure.DatabaseContext;

#nullable disable

namespace SheepManager.Infrastructure.Migrations
{
    [DbContext(typeof(SheepManagerDbContext))]
    [Migration("20240204112123_AddMatch_StoredProcedure")]
    partial class AddMatch_StoredProcedure
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SheepManager.Core.Domain.Entities.Herd", b =>
                {
                    b.Property<Guid>("HerdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HerdName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HerdId");

                    b.ToTable("Herds");
                });

            modelBuilder.Entity("SheepManager.Core.Domain.Entities.Livestock", b =>
                {
                    b.Property<Guid>("LivestockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HerdId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HerdStatisticsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LivestockId");

                    b.ToTable("Livestocks");
                });

            modelBuilder.Entity("SheepManager.Core.Domain.Entities.Match", b =>
                {
                    b.Property<Guid>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FemaleTagNumber")
                        .HasColumnType("int");

                    b.Property<int>("MaleTagNumber")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("SheepManager.Core.Domain.Entities.Sheep", b =>
                {
                    b.Property<Guid>("SheepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BloodType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FatherTagNumber")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HerdId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDead")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPregnant")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit");

                    b.Property<int>("MotherTagNumber")
                        .HasColumnType("int");

                    b.Property<string>("Race")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Selection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TagNumber")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("SheepId");

                    b.ToTable("Sheeps");
                });

            modelBuilder.Entity("SheepManager.Core.Domain.Entities.Vaccine", b =>
                {
                    b.Property<Guid>("VaccineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsForBirth")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMandatory")
                        .HasColumnType("bit");

                    b.Property<int>("SheepTagNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("VaccinationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VaccineName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VaccineId");

                    b.ToTable("Vaccines");
                });
#pragma warning restore 612, 618
        }
    }
}

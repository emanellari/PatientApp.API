﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientApp.API.Data;

#nullable disable

namespace PatientApp.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230428091150_Added_Refrence_To_Tables")]
    partial class Added_Refrence_To_Tables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PatientApp.API.Data.Models.Patient", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                b.Property<DateTime>("DOB")
                    .HasColumnType("datetime2");

                b.Property<DateTime>("DateCreated")
                    .HasColumnType("datetime2");

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<double>("GPA")
                    .HasColumnType("float");

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("PatientNumber")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("DoctorId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("DoctorId");

                b.ToTable("Patients");
            });

            modelBuilder.Entity("PatientApp.API.Data.Models.Doctor", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                b.Property<string>("Code")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<DateTime>("DateCreated")
                    .HasColumnType("datetime2");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Doctors");
            });

            modelBuilder.Entity("PatientApp.API.Data.Models.Patient", b =>
            {
                b.HasOne("PatientApp.API.Data.Models.Doctor", null)
                    .WithMany("Patients")
                    .HasForeignKey("DoctorId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("PatientApp.API.Data.Models.Doctor", b =>
            {
                b.Navigation("Patients");
            });
#pragma warning restore 612, 618
        }
    }
}


﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LetterMail.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AppointmentLetter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AnnualCTC")
                        .HasColumnType("numeric");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("MonthlyCTC")
                        .HasColumnType("numeric");

                    b.Property<byte[]>("PdfAttachment")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("AppointmentLetters");
                });

            modelBuilder.Entity("LetterMail.Components.Pages.CertificationLetter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmployeeID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmployeeType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HtmlContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RecipientEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Skill")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("CertificationLetters");
                });

            modelBuilder.Entity("LetterMail.Models.ExperienceLetter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmployeeID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HtmlContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RecipientEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("ExperienceLetters");
                });

            modelBuilder.Entity("RelievingLetter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("IssuanceDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RecipientEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("RelievingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ResignationDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("RelievingLetters");
                });

            modelBuilder.Entity("SalaryIncrement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EffectiveDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("NewSalary")
                        .HasColumnType("numeric");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SalaryIncrements");
                });
#pragma warning restore 612, 618
        }
    }
}
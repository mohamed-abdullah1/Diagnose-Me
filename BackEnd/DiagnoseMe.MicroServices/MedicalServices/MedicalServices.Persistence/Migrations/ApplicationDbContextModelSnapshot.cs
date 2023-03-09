﻿// <auto-generated />
using System;
using MedicalServices.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedicalServices.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MedicalServices.Domain.Entities.Check", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 3, 9, 12, 50, 39, 584, DateTimeKind.Utc).AddTicks(4491));

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("MedicalRecordId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Report")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("MedicalRecordId");

                    b.ToTable("Checks", (string)null);
                });

            modelBuilder.Entity("MedicalServices.Domain.Entities.Clinic", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 3, 9, 12, 50, 39, 590, DateTimeKind.Utc).AddTicks(620));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Clinics", (string)null);
                });

            modelBuilder.Entity("MedicalServices.Domain.Entities.Doctor", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ClinicId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 3, 9, 12, 50, 39, 593, DateTimeKind.Utc).AddTicks(5925));

                    b.Property<bool>("IsLicenseVerified")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("License")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.ToTable("Doctors", (string)null);
                });

            modelBuilder.Entity("MedicalServices.Domain.Entities.DoctorRate", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 3, 9, 12, 50, 39, 594, DateTimeKind.Utc).AddTicks(4617));

                    b.Property<string>("DoctorId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PatientId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("DoctorRates", (string)null);
                });

            modelBuilder.Entity("MedicalServices.Domain.Entities.MedicalRecord", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 3, 9, 12, 50, 39, 590, DateTimeKind.Utc).AddTicks(8657));

                    b.Property<string>("Diagnoses")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DoctorId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Illness")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PatientId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("MedicalRecords", (string)null);
                });

            modelBuilder.Entity("MedicalServices.Domain.Entities.Medicine", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Concentration")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 3, 9, 12, 50, 39, 592, DateTimeKind.Utc).AddTicks(4216));

                    b.Property<string>("Dose")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MedicalRecordId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MedicalRecordId");

                    b.ToTable("Medicines", (string)null);
                });

            modelBuilder.Entity("MedicalServices.Domain.Entities.Patient", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 3, 9, 12, 50, 39, 595, DateTimeKind.Utc).AddTicks(8960));

                    b.Property<float>("Height")
                        .HasColumnType("float");

                    b.Property<float>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Patients", (string)null);
                });

            modelBuilder.Entity("MedicalServices.Domain.Entities.PatientDoctor", b =>
                {
                    b.Property<string>("PatientId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DoctorId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Id")
                        .HasColumnType("longtext");

                    b.HasKey("PatientId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("PatientDoctors", (string)null);
                });

            modelBuilder.Entity("MedicalServices.Domain.Entities.Check", b =>
                {
                    b.HasOne("MedicalServices.Domain.Entities.MedicalRecord", "MedicalRecord")
                        .WithMany("Checks")
                        .HasForeignKey("MedicalRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalRecord");
                });

            modelBuilder.Entity("MedicalServices.Domain.Entities.Doctor", b =>
                {
                    b.HasOne("MedicalServices.Domain.Entities.Clinic", null)
                        .WithMany("Doctors")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedicalServices.Domain.Entities.DoctorRate", b =>
                {
                    b.HasOne("MedicalServices.Domain.Entities.Doctor", "Doctor")
                        .WithMany("DoctorRates")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalServices.Domain.Entities.Patient", "Patient")
                        .WithMany("DoctorRates")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("MedicalServices.Domain.Entities.MedicalRecord", b =>
                {
                    b.HasOne("MedicalServices.Domain.Entities.Doctor", "Doctor")
                        .WithMany("MedicalRecords")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalServices.Domain.Entities.Patient", "Patient")
                        .WithMany("MedicalRecords")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("MedicalServices.Domain.Entities.Medicine", b =>
                {
                    b.HasOne("MedicalServices.Domain.Entities.MedicalRecord", "MedicalRecord")
                        .WithMany("Medicines")
                        .HasForeignKey("MedicalRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalRecord");
                });

            modelBuilder.Entity("MedicalServices.Domain.Entities.PatientDoctor", b =>
                {
                    b.HasOne("MedicalServices.Domain.Entities.Doctor", "Doctor")
                        .WithMany("PatientDoctors")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalServices.Domain.Entities.Patient", "Patient")
                        .WithMany("PatientDoctors")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("MedicalServices.Domain.Entities.Clinic", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("MedicalServices.Domain.Entities.Doctor", b =>
                {
                    b.Navigation("DoctorRates");

                    b.Navigation("MedicalRecords");

                    b.Navigation("PatientDoctors");
                });

            modelBuilder.Entity("MedicalServices.Domain.Entities.MedicalRecord", b =>
                {
                    b.Navigation("Checks");

                    b.Navigation("Medicines");
                });

            modelBuilder.Entity("MedicalServices.Domain.Entities.Patient", b =>
                {
                    b.Navigation("DoctorRates");

                    b.Navigation("MedicalRecords");

                    b.Navigation("PatientDoctors");
                });
#pragma warning restore 612, 618
        }
    }
}

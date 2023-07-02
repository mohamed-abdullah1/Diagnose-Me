﻿// <auto-generated />
using System;
using BloodDonation.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BloodDonation.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230619204426_removeProfilePicRequire")]
    partial class removeProfilePicRequire
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BloodDonation.Domain.Entities.DonationRequest", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BloodType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 6, 19, 20, 44, 26, 210, DateTimeKind.Utc).AddTicks(965));

                    b.Property<string>("DonnerId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RequesterId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("RequesterId");

                    b.ToTable("DonationRequests", (string)null);
                });

            modelBuilder.Entity("BloodDonation.Domain.Entities.DonnerDonationRequest", b =>
                {
                    b.Property<string>("DonnerId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DonationRequestId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Id")
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("DonnerId", "DonationRequestId");

                    b.HasIndex("DonationRequestId");

                    b.ToTable("DonnerDonationRequests", (string)null);
                });

            modelBuilder.Entity("BloodDonation.Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BloodType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 6, 19, 20, 44, 26, 212, DateTimeKind.Utc).AddTicks(982));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastDonationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProfilePictureUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "972a1201-a9dc-2127-0827-560cb7d76af8",
                            BloodType = "A+",
                            CreatedOn = new DateTime(2023, 6, 19, 20, 44, 26, 212, DateTimeKind.Utc).AddTicks(2292),
                            FullName = "Patient",
                            Name = "Patient",
                            ProfilePictureUrl = ""
                        },
                        new
                        {
                            Id = "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
                            BloodType = "A+",
                            CreatedOn = new DateTime(2023, 6, 19, 20, 44, 26, 212, DateTimeKind.Utc).AddTicks(2338),
                            FullName = "Doctor",
                            Name = "Doctor",
                            ProfilePictureUrl = ""
                        },
                        new
                        {
                            Id = "00edafe3-b047-5980-d0fa-da10f400c1e5",
                            BloodType = "A+",
                            CreatedOn = new DateTime(2023, 6, 19, 20, 44, 26, 212, DateTimeKind.Utc).AddTicks(2357),
                            FullName = "Admin",
                            Name = "Admin",
                            ProfilePictureUrl = ""
                        });
                });

            modelBuilder.Entity("BloodDonation.Domain.Entities.DonationRequest", b =>
                {
                    b.HasOne("BloodDonation.Domain.Entities.User", "Requester")
                        .WithMany("DonationRequests")
                        .HasForeignKey("RequesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Requester");
                });

            modelBuilder.Entity("BloodDonation.Domain.Entities.DonnerDonationRequest", b =>
                {
                    b.HasOne("BloodDonation.Domain.Entities.DonationRequest", "DonationRequest")
                        .WithMany("DonnerDonationRequests")
                        .HasForeignKey("DonationRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodDonation.Domain.Entities.User", "Donner")
                        .WithMany("DonnerDonationRequests")
                        .HasForeignKey("DonnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonationRequest");

                    b.Navigation("Donner");
                });

            modelBuilder.Entity("BloodDonation.Domain.Entities.DonationRequest", b =>
                {
                    b.Navigation("DonnerDonationRequests");
                });

            modelBuilder.Entity("BloodDonation.Domain.Entities.User", b =>
                {
                    b.Navigation("DonationRequests");

                    b.Navigation("DonnerDonationRequests");
                });
#pragma warning restore 612, 618
        }
    }
}

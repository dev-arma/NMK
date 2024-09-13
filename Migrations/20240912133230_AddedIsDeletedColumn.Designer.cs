﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NMK.Data;

#nullable disable

namespace NMK.Migrations
{
    [DbContext(typeof(NMKDbContext))]
    [Migration("20240912133230_AddedIsDeletedColumn")]
    partial class AddedIsDeletedColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("NMK.Models.Admission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdmitted")
                        .HasColumnType("TEXT");

                    b.Property<int>("DoctorId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Emergency")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Admissions");
                });

            modelBuilder.Entity("NMK.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DoctorCode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("NMK.Models.MedicalReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfReport")
                        .HasColumnType("TEXT");

                    b.Property<int>("DoctorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReportText")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("MedicalReports");
                });

            modelBuilder.Entity("NMK.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NameAndSurname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("NMK.Models.Admission", b =>
                {
                    b.HasOne("NMK.Models.Doctor", "Doctor")
                        .WithMany("Admissions")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NMK.Models.Patient", "Patient")
                        .WithMany("Admissions")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("NMK.Models.MedicalReport", b =>
                {
                    b.HasOne("NMK.Models.Doctor", "Doctor")
                        .WithMany("MedicalReports")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NMK.Models.Patient", "Patient")
                        .WithMany("MedicalReports")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("NMK.Models.Doctor", b =>
                {
                    b.Navigation("Admissions");

                    b.Navigation("MedicalReports");
                });

            modelBuilder.Entity("NMK.Models.Patient", b =>
                {
                    b.Navigation("Admissions");

                    b.Navigation("MedicalReports");
                });
#pragma warning restore 612, 618
        }
    }
}

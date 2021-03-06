﻿// <auto-generated />
using System;
using BookMark.OrmData.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookMark.OrmData.Migrations
{
    [DbContext(typeof(BookMarkDbContext))]
    [Migration("20200402021909_mgn")]
    partial class mgn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookMark.Domain.Models.Appointment", b =>
                {
                    b.Property<long>("AppointmentID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("AppointmentID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("BookMark.Domain.Models.User", b =>
                {
                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1L,
                            Name = "synaodev",
                            Password = "$2a$11$ygV8d1uNHxNcdIH1S0m/aORPyeJ7I6.UBCJ.35j.C8O9K9Dyy6bYy"
                        });
                });

            modelBuilder.Entity("BookMark.Domain.Models.UserAppointment", b =>
                {
                    b.Property<long>("UserAppointmentID")
                        .HasColumnType("bigint");

                    b.Property<long>("AppointmentID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("UserAppointmentID");

                    b.HasIndex("AppointmentID");

                    b.HasIndex("UserID");

                    b.ToTable("UserAppointment");
                });

            modelBuilder.Entity("BookMark.Domain.Models.UserAppointment", b =>
                {
                    b.HasOne("BookMark.Domain.Models.Appointment", "Appointment")
                        .WithMany("UserAppointments")
                        .HasForeignKey("AppointmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookMark.Domain.Models.User", "User")
                        .WithMany("UserAppointments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

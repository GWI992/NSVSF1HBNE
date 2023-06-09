﻿// <auto-generated />
using System;
using Endpoint.Repositories.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Endpoint.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Endpoint.Models.Data.Reservation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<DateTime>("Begin")
                        .HasColumnType("datetime2")
                        .HasColumnName("begin");

                    b.Property<DateTime>("Contact")
                        .HasColumnType("datetime2")
                        .HasColumnName("contact");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2")
                        .HasColumnName("end");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<int>("Person")
                        .HasColumnType("int")
                        .HasColumnName("person");

                    b.Property<string>("TableId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("table_id");

                    b.HasKey("Id");

                    b.HasIndex("TableId");

                    b.ToTable("reservation");
                });

            modelBuilder.Entity("Endpoint.Models.Data.Table", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id");

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("capacity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("tables");
                });

            modelBuilder.Entity("Endpoint.Models.Data.Reservation", b =>
                {
                    b.HasOne("Endpoint.Models.Data.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("Endpoint.Models.Data.Table", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}

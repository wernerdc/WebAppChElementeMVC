﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppChElementeMVC.Data;

#nullable disable

namespace WebAppChElementeMVC.Migrations
{
    [DbContext(typeof(WebAppChElementeMVCContext))]
    [Migration("20241112090634_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAppChElementeMVC.Models.Element", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GruppeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ordnungszahl")
                        .HasColumnType("int");

                    b.Property<int>("PeriodeId")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZustandId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GruppeId");

                    b.HasIndex("PeriodeId");

                    b.HasIndex("ZustandId");

                    b.ToTable("Element");
                });

            modelBuilder.Entity("WebAppChElementeMVC.Models.Gruppe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Nummer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Gruppe");
                });

            modelBuilder.Entity("WebAppChElementeMVC.Models.Periode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nummer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Periode");
                });

            modelBuilder.Entity("WebAppChElementeMVC.Models.Zustand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bezeichnung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Zustand");
                });

            modelBuilder.Entity("WebAppChElementeMVC.Models.Element", b =>
                {
                    b.HasOne("WebAppChElementeMVC.Models.Gruppe", "Gruppe")
                        .WithMany("Elemente")
                        .HasForeignKey("GruppeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAppChElementeMVC.Models.Periode", "Periode")
                        .WithMany("Elemente")
                        .HasForeignKey("PeriodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAppChElementeMVC.Models.Zustand", "Zustand")
                        .WithMany("Elemente")
                        .HasForeignKey("ZustandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gruppe");

                    b.Navigation("Periode");

                    b.Navigation("Zustand");
                });

            modelBuilder.Entity("WebAppChElementeMVC.Models.Gruppe", b =>
                {
                    b.Navigation("Elemente");
                });

            modelBuilder.Entity("WebAppChElementeMVC.Models.Periode", b =>
                {
                    b.Navigation("Elemente");
                });

            modelBuilder.Entity("WebAppChElementeMVC.Models.Zustand", b =>
                {
                    b.Navigation("Elemente");
                });
#pragma warning restore 612, 618
        }
    }
}
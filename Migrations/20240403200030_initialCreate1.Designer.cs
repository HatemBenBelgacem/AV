﻿// <auto-generated />
using AV.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AV.Migrations
{
    [DbContext(typeof(AVContext))]
    [Migration("20240403200030_initialCreate1")]
    partial class initialCreate1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("AV.Models.Adresse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Adressen");
                });

            modelBuilder.Entity("AV.Models.Auftrag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AdresseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Beschreibung")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AdresseId")
                        .IsUnique();

                    b.ToTable("Auftraege");
                });

            modelBuilder.Entity("AV.Models.Auftrag", b =>
                {
                    b.HasOne("AV.Models.Adresse", "Adresse")
                        .WithOne("Auftrag")
                        .HasForeignKey("AV.Models.Auftrag", "AdresseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adresse");
                });

            modelBuilder.Entity("AV.Models.Adresse", b =>
                {
                    b.Navigation("Auftrag");
                });
#pragma warning restore 612, 618
        }
    }
}

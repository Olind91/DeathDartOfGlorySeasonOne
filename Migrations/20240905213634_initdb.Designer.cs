﻿// <auto-generated />
using System;
using DeathDartOfGlorySeasonOne.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DeathDartOfGlorySeasonOne.Migrations
{
    [DbContext(typeof(DartContext))]
    [Migration("20240905213634_initdb")]
    partial class initdb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DeathDartOfGlorySeasonOne.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfGames")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("DeathDartOfGlorySeasonOne.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("DeathDartOfGlorySeasonOne.Models.PlayerScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayerScores");
                });

            modelBuilder.Entity("DeathDartOfGlorySeasonOne.Models.PlayerScore", b =>
                {
                    b.HasOne("DeathDartOfGlorySeasonOne.Models.Match", null)
                        .WithMany("PlayerScores")
                        .HasForeignKey("MatchId");

                    b.HasOne("DeathDartOfGlorySeasonOne.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("DeathDartOfGlorySeasonOne.Models.Match", b =>
                {
                    b.Navigation("PlayerScores");
                });
#pragma warning restore 612, 618
        }
    }
}

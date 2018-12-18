﻿// <auto-generated />
using System;
using DataToAdvertisementTransformer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataToAdvertisementTransformer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181217142110_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DataToAdvertisementTransformer.Models.Keyword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("Keywords");
                });

            modelBuilder.Entity("DataToAdvertisementTransformer.Models.KeywordLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("KeywordId");

                    b.Property<string>("Location");

                    b.HasKey("Id");

                    b.HasIndex("KeywordId");

                    b.ToTable("KeywordLocations");
                });

            modelBuilder.Entity("DataToAdvertisementTransformer.Models.KeywordLocation", b =>
                {
                    b.HasOne("DataToAdvertisementTransformer.Models.Keyword", "Keyword")
                        .WithMany("KeywordLocations")
                        .HasForeignKey("KeywordId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
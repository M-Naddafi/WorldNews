﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorldNews.DataLayer.Context;

#nullable disable

namespace WorldNews.DataLayer.Migrations
{
    [DbContext(typeof(WNewsContext))]
    [Migration("20230723135254_mig_newsFix")]
    partial class mig_newsFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WorldNews.DataLayer.Models.News", b =>
                {
                    b.Property<int>("NewsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NewsId"));

                    b.Property<bool>("BreakingNews")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HighlightNews")
                        .HasColumnType("bit");

                    b.Property<string>("NewsDescription")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<string>("NewsImage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NewsTitle")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("NewsId");

                    b.HasIndex("SectionId");

                    b.HasIndex("UserId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("WorldNews.DataLayer.Models.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SectionId"));

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SectionId");

                    b.ToTable("Section");

                    b.HasData(
                        new
                        {
                            SectionId = 1,
                            SectionName = "جهان"
                        },
                        new
                        {
                            SectionId = 2,
                            SectionName = "اقتصادی"
                        },
                        new
                        {
                            SectionId = 3,
                            SectionName = "تکنولوژی"
                        },
                        new
                        {
                            SectionId = 4,
                            SectionName = "ورزشی"
                        },
                        new
                        {
                            SectionId = 5,
                            SectionName = "فرهنگی"
                        });
                });

            modelBuilder.Entity("WorldNews.DataLayer.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WorldNews.DataLayer.Models.News", b =>
                {
                    b.HasOne("WorldNews.DataLayer.Models.Section", "Section")
                        .WithMany("News")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorldNews.DataLayer.Models.User", "User")
                        .WithMany("News")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WorldNews.DataLayer.Models.Section", b =>
                {
                    b.Navigation("News");
                });

            modelBuilder.Entity("WorldNews.DataLayer.Models.User", b =>
                {
                    b.Navigation("News");
                });
#pragma warning restore 612, 618
        }
    }
}

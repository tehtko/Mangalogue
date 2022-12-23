﻿// <auto-generated />
using System;
using Mangalogue.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mangalogue.Migrations
{
    [DbContext(typeof(MDataContext))]
    [Migration("20221223010546_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Mangalogue.Entities.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ChapterNumber")
                        .HasColumnType("int");

                    b.Property<int?>("MangaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MangaId");

                    b.ToTable("Chapter");
                });

            modelBuilder.Entity("Mangalogue.Entities.Favourites", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MangaId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MangaId");

                    b.HasIndex("UserId");

                    b.ToTable("Favourites");
                });

            modelBuilder.Entity("Mangalogue.Entities.Manga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Rating")
                        .HasColumnType("float");

                    b.Property<byte[]>("Thumbnail")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Mangas");
                });

            modelBuilder.Entity("Mangalogue.Entities.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ChapterId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("Page");
                });

            modelBuilder.Entity("Mangalogue.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProfileImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Mangalogue.Entities.Chapter", b =>
                {
                    b.HasOne("Mangalogue.Entities.Manga", null)
                        .WithMany("Chapters")
                        .HasForeignKey("MangaId");
                });

            modelBuilder.Entity("Mangalogue.Entities.Favourites", b =>
                {
                    b.HasOne("Mangalogue.Entities.Manga", "Manga")
                        .WithMany()
                        .HasForeignKey("MangaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mangalogue.Entities.User", null)
                        .WithMany("Favorites")
                        .HasForeignKey("UserId");

                    b.Navigation("Manga");
                });

            modelBuilder.Entity("Mangalogue.Entities.Manga", b =>
                {
                    b.HasOne("Mangalogue.Entities.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Mangalogue.Entities.Page", b =>
                {
                    b.HasOne("Mangalogue.Entities.Chapter", null)
                        .WithMany("Pages")
                        .HasForeignKey("ChapterId");
                });

            modelBuilder.Entity("Mangalogue.Entities.Chapter", b =>
                {
                    b.Navigation("Pages");
                });

            modelBuilder.Entity("Mangalogue.Entities.Manga", b =>
                {
                    b.Navigation("Chapters");
                });

            modelBuilder.Entity("Mangalogue.Entities.User", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}

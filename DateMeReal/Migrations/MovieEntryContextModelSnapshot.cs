﻿// <auto-generated />
using DateMeReal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DateMeReal.Migrations
{
    [DbContext(typeof(MovieEntryContext))]
    partial class MovieEntryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("DateMeReal.Models.ApplicationEntry", b =>
                {
                    b.Property<int>("EntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LentTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EntryId");

                    b.HasIndex("CategoryID");

                    b.ToTable("responses");

                    b.HasData(
                        new
                        {
                            EntryId = 1,
                            CategoryID = 3,
                            Director = "Damien Chazelle",
                            Edited = false,
                            LentTo = "",
                            MovieName = "La La Land",
                            Notes = "A really good movie that makes you think.",
                            Rating = "PG-13",
                            Year = "2016"
                        },
                        new
                        {
                            EntryId = 2,
                            CategoryID = 6,
                            Director = "Brad Bird",
                            Edited = false,
                            LentTo = "",
                            MovieName = "Ratatouille",
                            Notes = "Vibes are unmatched.",
                            Rating = "PG",
                            Year = "2007"
                        },
                        new
                        {
                            EntryId = 3,
                            CategoryID = 1,
                            Director = "Morten Tyldum",
                            Edited = false,
                            LentTo = "",
                            MovieName = "The Imitation Game",
                            Notes = "",
                            Rating = "PG-13",
                            Year = "2014"
                        });
                });

            modelBuilder.Entity("DateMeReal.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Action/Adventure"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Comedy"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Romance"
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Horror/Suspense"
                        },
                        new
                        {
                            CategoryID = 5,
                            CategoryName = "Drama"
                        },
                        new
                        {
                            CategoryID = 6,
                            CategoryName = "Family"
                        },
                        new
                        {
                            CategoryID = 7,
                            CategoryName = "Miscellaneous"
                        },
                        new
                        {
                            CategoryID = 8,
                            CategoryName = "Television"
                        },
                        new
                        {
                            CategoryID = 9,
                            CategoryName = "VHS"
                        });
                });

            modelBuilder.Entity("DateMeReal.Models.ApplicationEntry", b =>
                {
                    b.HasOne("DateMeReal.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

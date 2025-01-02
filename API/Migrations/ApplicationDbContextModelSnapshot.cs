﻿// <auto-generated />
using System;
using API.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("API.Persistence.Entities.Algorithm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Algorithms");
                });

            modelBuilder.Entity("API.Persistence.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CreditHour")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FullMark")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsElective")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SemesterId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("API.Persistence.Entities.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalCreditHour")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalFullMark")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("API.Persistence.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("API.Persistence.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Persistence.Entities.Visualization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlgorithmId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Css")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Html")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Js")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Views")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AlgorithmId");

                    b.HasIndex("UserId");

                    b.ToTable("Visualizations");
                });

            modelBuilder.Entity("API.Persistence.Entities.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VisualizationId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("VotedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VisualizationId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("AlgorithmTag", b =>
                {
                    b.Property<int>("AlgorithmsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlgorithmsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("AlgorithmTag");
                });

            modelBuilder.Entity("API.Persistence.Entities.Algorithm", b =>
                {
                    b.HasOne("API.Persistence.Entities.Course", "Course")
                        .WithMany("Algorithms")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("API.Persistence.Entities.Course", b =>
                {
                    b.HasOne("API.Persistence.Entities.Semester", "Semester")
                        .WithMany("Courses")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("API.Persistence.Entities.Visualization", b =>
                {
                    b.HasOne("API.Persistence.Entities.Algorithm", "Algorithm")
                        .WithMany("Visualizations")
                        .HasForeignKey("AlgorithmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Persistence.Entities.User", "User")
                        .WithMany("Visualizations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Algorithm");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Persistence.Entities.Vote", b =>
                {
                    b.HasOne("API.Persistence.Entities.User", null)
                        .WithMany("Votes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Persistence.Entities.Visualization", null)
                        .WithMany("Votes")
                        .HasForeignKey("VisualizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlgorithmTag", b =>
                {
                    b.HasOne("API.Persistence.Entities.Algorithm", null)
                        .WithMany()
                        .HasForeignKey("AlgorithmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Persistence.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Persistence.Entities.Algorithm", b =>
                {
                    b.Navigation("Visualizations");
                });

            modelBuilder.Entity("API.Persistence.Entities.Course", b =>
                {
                    b.Navigation("Algorithms");
                });

            modelBuilder.Entity("API.Persistence.Entities.Semester", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("API.Persistence.Entities.User", b =>
                {
                    b.Navigation("Visualizations");

                    b.Navigation("Votes");
                });

            modelBuilder.Entity("API.Persistence.Entities.Visualization", b =>
                {
                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using DreamDiary.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DreamDiary.DAL.Migrations
{
    [DbContext(typeof(DreamContext))]
    partial class DreamContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DreamDiary.DAL.Entities.Dream", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ImageGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProfileGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.HasIndex("ImageGuid");

                    b.HasIndex("ProfileGuid");

                    b.ToTable("Dreams");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.Goal", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ImageGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProfileGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.HasIndex("ImageGuid");

                    b.HasIndex("ProfileGuid");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.GoalTask", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.ImageDream", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Guid");

                    b.ToTable("DreamImages");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.ImageGoal", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Guid");

                    b.ToTable("GoalImages");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.ImageProfile", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("ProfileGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Guid");

                    b.HasIndex("ProfileGuid")
                        .IsUnique();

                    b.ToTable("ImageProfiles");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.NoteGoal", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GoalGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.HasIndex("GoalGuid");

                    b.ToTable("GoalNotes");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.NoteProfile", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProfileGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.HasIndex("ProfileGuid");

                    b.ToTable("ProfileNotes");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.NoteTask", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TaskGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.HasIndex("TaskGuid");

                    b.ToTable("TaskNotes");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.UserProfile", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ImageProfileGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Guid");

                    b.HasIndex("ImageProfileGuid");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.Dream", b =>
                {
                    b.HasOne("DreamDiary.DAL.Entities.ImageDream", "Image")
                        .WithMany()
                        .HasForeignKey("ImageGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DreamDiary.DAL.Entities.UserProfile", "UserProfile")
                        .WithMany("Dreams")
                        .HasForeignKey("ProfileGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.Goal", b =>
                {
                    b.HasOne("DreamDiary.DAL.Entities.ImageGoal", "Image")
                        .WithMany()
                        .HasForeignKey("ImageGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DreamDiary.DAL.Entities.UserProfile", "UserProfile")
                        .WithMany()
                        .HasForeignKey("ProfileGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.ImageProfile", b =>
                {
                    b.HasOne("DreamDiary.DAL.Entities.UserProfile", "UserProfile")
                        .WithOne()
                        .HasForeignKey("DreamDiary.DAL.Entities.ImageProfile", "ProfileGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.NoteGoal", b =>
                {
                    b.HasOne("DreamDiary.DAL.Entities.Goal", "Goal")
                        .WithMany("GoalNotes")
                        .HasForeignKey("GoalGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Goal");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.NoteProfile", b =>
                {
                    b.HasOne("DreamDiary.DAL.Entities.UserProfile", "Profile")
                        .WithMany("ProfileNotes")
                        .HasForeignKey("ProfileGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.NoteTask", b =>
                {
                    b.HasOne("DreamDiary.DAL.Entities.GoalTask", "Task")
                        .WithMany("TaskNotes")
                        .HasForeignKey("TaskGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.UserProfile", b =>
                {
                    b.HasOne("DreamDiary.DAL.Entities.ImageProfile", "ImageProfile")
                        .WithMany()
                        .HasForeignKey("ImageProfileGuid");

                    b.HasOne("DreamDiary.DAL.Entities.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("DreamDiary.DAL.Entities.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImageProfile");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.Goal", b =>
                {
                    b.Navigation("GoalNotes");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.GoalTask", b =>
                {
                    b.Navigation("TaskNotes");
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.User", b =>
                {
                    b.Navigation("Profile")
                        .IsRequired();
                });

            modelBuilder.Entity("DreamDiary.DAL.Entities.UserProfile", b =>
                {
                    b.Navigation("Dreams");

                    b.Navigation("ProfileNotes");
                });
#pragma warning restore 612, 618
        }
    }
}

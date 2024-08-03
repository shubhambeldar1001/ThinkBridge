﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240729084927_AddTeamMemberId")]
    partial class AddTeamMemberId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskManagementSystem.Models.TaskAttachment", b =>
                {
                    b.Property<int>("TaskAttachmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UploadedBy")
                        .HasColumnType("int");

                    b.Property<int?>("UploadedUserUserId")
                        .HasColumnType("int");

                    b.HasKey("TaskAttachmentId");

                    b.HasIndex("TaskId");

                    b.HasIndex("UploadedUserUserId");

                    b.ToTable("TaskAttachments");
                });

            modelBuilder.Entity("TaskManagementSystem.Models.TaskNote", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoteContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("NoteId");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("TaskNotes");
                });

            modelBuilder.Entity("TaskManagementSystem.Models.TaskOffice", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignedTo")
                        .HasColumnType("int");

                    b.Property<int>("AssignedUserId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedUserUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.HasIndex("AssignedUserId");

                    b.HasIndex("CreatedUserUserId");

                    b.ToTable("TaskOffices");
                });

            modelBuilder.Entity("TaskManagementSystem.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TaskManagementSystem.Models.TeamMember", b =>
                {
                    b.Property<int>("TeamMemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamMemberId");

                    b.HasIndex("TeamId")
                        .IsUnique();

                    b.ToTable("TeamMembers");
                });

            modelBuilder.Entity("TaskManagementSystem.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamMemberId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("TeamMemberId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaskManagementSystem.Models.TaskAttachment", b =>
                {
                    b.HasOne("TaskManagementSystem.Models.TaskOffice", "Task")
                        .WithMany("TaskAttachments")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagementSystem.Models.User", "UploadedUser")
                        .WithMany()
                        .HasForeignKey("UploadedUserUserId");
                });

            modelBuilder.Entity("TaskManagementSystem.Models.TaskNote", b =>
                {
                    b.HasOne("TaskManagementSystem.Models.TaskOffice", "Task")
                        .WithMany("TaskNotes")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagementSystem.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaskManagementSystem.Models.TaskOffice", b =>
                {
                    b.HasOne("TaskManagementSystem.Models.User", "AssignedUser")
                        .WithMany()
                        .HasForeignKey("AssignedUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaskManagementSystem.Models.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserUserId");
                });

            modelBuilder.Entity("TaskManagementSystem.Models.TeamMember", b =>
                {
                    b.HasOne("TaskManagementSystem.Models.Team", null)
                        .WithOne("TeamMembers")
                        .HasForeignKey("TaskManagementSystem.Models.TeamMember", "TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaskManagementSystem.Models.User", b =>
                {
                    b.HasOne("TaskManagementSystem.Models.TeamMember", null)
                        .WithMany("User")
                        .HasForeignKey("TeamMemberId");
                });
#pragma warning restore 612, 618
        }
    }
}

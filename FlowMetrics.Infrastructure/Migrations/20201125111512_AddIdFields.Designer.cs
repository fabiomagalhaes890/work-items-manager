﻿// <auto-generated />
using System;
using FlowMetrics.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlowMetrics.Infrastructure.Migrations
{
    [DbContext(typeof(FlowMetricsContext))]
    [Migration("20201125111512_AddIdFields")]
    partial class AddIdFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("FlowMetrics.Work.Assignees.Assignee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Assignee");
                });

            modelBuilder.Entity("FlowMetrics.Work.Epics.Epic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Epic");
                });

            modelBuilder.Entity("FlowMetrics.Work.Weeks.Week", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Week");
                });

            modelBuilder.Entity("FlowMetrics.Work.WorkItems.WorkItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AcceptanceReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("AssigneeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AwaitingCodeReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("AwaitingTestsDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndImpedimentDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EpicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("InProgressDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IncludedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IssueId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ProductionReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReviewingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartImpedimentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TeamBacklogDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("TechDebt")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("TestingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TestsCompletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WeekId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("EpicId");

                    b.HasIndex("WeekId");

                    b.ToTable("WorkItem");
                });

            modelBuilder.Entity("FlowMetrics.Work.WorkItems.WorkItem", b =>
                {
                    b.HasOne("FlowMetrics.Work.Assignees.Assignee", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlowMetrics.Work.Epics.Epic", "Epic")
                        .WithMany()
                        .HasForeignKey("EpicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlowMetrics.Work.Weeks.Week", "Week")
                        .WithMany()
                        .HasForeignKey("WeekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignee");

                    b.Navigation("Epic");

                    b.Navigation("Week");
                });
#pragma warning restore 612, 618
        }
    }
}

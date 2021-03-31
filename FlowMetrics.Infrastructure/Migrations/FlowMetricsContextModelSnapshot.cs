﻿// <auto-generated />
using System;
using FlowMetrics.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlowMetrics.Infrastructure.Migrations
{
    [DbContext(typeof(FlowMetricsContext))]
    partial class FlowMetricsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Team")
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

                    b.Property<bool?>("ConsiderTTM")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EpicId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsPrioritized")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

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

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

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

                    b.Property<Guid?>("AssigneeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AwaitingAcceptanceTestsDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("AwaitingCodeReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("AwaitingProductionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("AwaitingTestsDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BacklogDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DoneDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndImpedimentDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EpicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ImpedimentKind")
                        .HasColumnType("int");

                    b.Property<DateTime?>("InProgressDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IssueId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Priority")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ProductionReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Removed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ReviewingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartImpedimentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Team")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TechDebt")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("TestingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TestingInAcceptanceDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ToDoDate")
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

            modelBuilder.Entity("FlowMetrics.Work.WorkToSheet.WorkSheet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AcceptanceReleaseDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Assignee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssigneeTeam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AwaitingAcceptanceTestsDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AwaitingCodeReviewDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AwaitingProductionDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AwaitingTestsDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BacklogDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoneDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndImpedimentDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Epic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InProgressDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IssueId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Priority")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductionReleaseDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewingDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartImpedimentDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechDebt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestingDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestingInAcceptanceDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToDoDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Week")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WorkItemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WorkItemId");

                    b.ToTable("WorkSheet");
                });

            modelBuilder.Entity("FlowMetrics.Work.WorkItems.WorkItem", b =>
                {
                    b.HasOne("FlowMetrics.Work.Assignees.Assignee", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId");

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

            modelBuilder.Entity("FlowMetrics.Work.WorkToSheet.WorkSheet", b =>
                {
                    b.HasOne("FlowMetrics.Work.WorkItems.WorkItem", "WorkItem")
                        .WithMany()
                        .HasForeignKey("WorkItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkItem");
                });
#pragma warning restore 612, 618
        }
    }
}

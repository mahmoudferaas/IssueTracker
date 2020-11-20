﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Terkwaz.IssueTracker.Persistence;

namespace Terkwaz.IssueTracker.Persistence.Migrations
{
    [DbContext(typeof(IssueTrackerDbContext))]
    partial class IssueTrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Terkwaz.IssueTracker.Domain.Entities.Issue", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AssigneeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IssueTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("ReporterId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("IssueTypeId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ReporterId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("Terkwaz.IssueTracker.Domain.Entities.IssueType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IssueTypes");
                });

            modelBuilder.Entity("Terkwaz.IssueTracker.Domain.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Terkwaz.IssueTracker.Domain.Entities.ProjectParticipants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectParticipants");
                });

            modelBuilder.Entity("Terkwaz.IssueTracker.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Terkwaz.IssueTracker.Domain.Entities.Issue", b =>
                {
                    b.HasOne("Terkwaz.IssueTracker.Domain.Entities.User", "Assignee")
                        .WithMany("IssueAssignees")
                        .HasForeignKey("AssigneeId")
                        .HasConstraintName("Issue_AssigneeId_FK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Terkwaz.IssueTracker.Domain.Entities.IssueType", "IssueType")
                        .WithMany("Issues")
                        .HasForeignKey("IssueTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Terkwaz.IssueTracker.Domain.Entities.Project", "Project")
                        .WithMany("Issues")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("Issue_ProjectId_FK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Terkwaz.IssueTracker.Domain.Entities.User", "Reporter")
                        .WithMany("IssueReporters")
                        .HasForeignKey("ReporterId")
                        .HasConstraintName("Issue_ReporterId_FK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Assignee");

                    b.Navigation("IssueType");

                    b.Navigation("Project");

                    b.Navigation("Reporter");
                });

            modelBuilder.Entity("Terkwaz.IssueTracker.Domain.Entities.Project", b =>
                {
                    b.HasOne("Terkwaz.IssueTracker.Domain.Entities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Terkwaz.IssueTracker.Domain.Entities.ProjectParticipants", b =>
                {
                    b.HasOne("Terkwaz.IssueTracker.Domain.Entities.User", "Participant")
                        .WithMany("ProjectParticipants")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Terkwaz.IssueTracker.Domain.Entities.Project", "Project")
                        .WithMany("ProjectParticipants")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Participant");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Terkwaz.IssueTracker.Domain.Entities.IssueType", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("Terkwaz.IssueTracker.Domain.Entities.Project", b =>
                {
                    b.Navigation("Issues");

                    b.Navigation("ProjectParticipants");
                });

            modelBuilder.Entity("Terkwaz.IssueTracker.Domain.Entities.User", b =>
                {
                    b.Navigation("IssueAssignees");

                    b.Navigation("IssueReporters");

                    b.Navigation("ProjectParticipants");
                });
#pragma warning restore 612, 618
        }
    }
}

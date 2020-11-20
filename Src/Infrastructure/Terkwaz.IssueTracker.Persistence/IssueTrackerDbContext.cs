using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Interfaces;
using Terkwaz.IssueTracker.Domain.Entities;

namespace Terkwaz.IssueTracker.Persistence
{
    public class IssueTrackerDbContext : DbContext, IIssueTrackerDbContext
    {
        public IssueTrackerDbContext(DbContextOptions<IssueTrackerDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueType> IssueTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectParticipants> ProjectParticipants { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProjectParticipants>()
                       .HasOne(pb => pb.Project)
                       .WithMany(p => p.ProjectParticipants)
                       .HasForeignKey(pb => pb.ProjectId)
                       .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProjectParticipants>()
                      .HasOne(pb => pb.Participant)
                      .WithMany(p => p.ProjectParticipants)
                      .HasForeignKey(pb => pb.ParticipantId)
                      .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Issue>(act =>
            {
                act.HasOne(field => field.Assignee)
                .WithMany(fk => fk.IssueAssignees)
                .HasForeignKey(fk => fk.AssigneeId).OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Issue_AssigneeId_FK");

                act.HasOne(field => field.Reporter)
                .WithMany(fk => fk.IssueReporters)
                .HasForeignKey(fk => fk.ReporterId).OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Issue_ReporterId_FK");

            });

            modelBuilder.Entity<Issue>(act =>
            {
                act.HasOne(field => field.Project)
                .WithMany(fk => fk.Issues)
                .HasForeignKey(fk => fk.ProjectId).OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("Issue_ProjectId_FK");
            });

            //modelBuilder.Entity<Issue>()
            //          .HasOne(pb => pb.Project)
            //          .WithMany(p => p.Issues)
            //          .HasForeignKey(pb => pb.ProjectId);

            modelBuilder.Entity<Issue>()
                      .HasOne(pb => pb.IssueType)
                      .WithMany(p => p.Issues)
                      .HasForeignKey(pb => pb.IssueTypeId)
                      .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
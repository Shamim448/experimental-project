using System;
using System.Collections.Generic;
using DevJobs.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DevJobs.API.Data;

public  class ApplicationDbContext : DbContext
{


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ExperienceMapping> ExperienceMappings { get; set; }

    public virtual DbSet<JobAnalysis> JobAnalyses { get; set; }

    public virtual DbSet<JobPost> JobPosts { get; set; }

    public virtual DbSet<JobTechnology> JobTechnologies { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Technology> Technologies { get; set; }

    public virtual DbSet<TrackMapping> TrackMappings { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExperienceMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.ExperienceMapping");

            entity.ToTable("ExperienceMapping");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<JobAnalysis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.JobAnalysis");

            entity.ToTable("JobAnalysis");

            entity.HasIndex(e => e.JobPostId, "IX_JobPostID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.JobPostId).HasColumnName("JobPostID");

            entity.HasOne(d => d.JobPost).WithMany(p => p.JobAnalyses)
                .HasForeignKey(d => d.JobPostId)
                .HasConstraintName("FK_dbo.JobAnalysis_dbo.JobPost_JobPostID");
        });

        modelBuilder.Entity<JobPost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.JobPost");

            entity.ToTable("JobPost");

            entity.HasIndex(e => e.OrganizationId, "IX_OrganizationID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");
            entity.Property(e => e.PublishedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Organization).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK_dbo.JobPost_dbo.Organization_OrganizationID");
        });

        modelBuilder.Entity<JobTechnology>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.JobTechnology");

            entity.ToTable("JobTechnology");

            entity.HasIndex(e => e.JobAnalysisId, "IX_JobAnalysis_ID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.JobAnalysisId).HasColumnName("JobAnalysis_ID");

            entity.HasOne(d => d.JobAnalysis).WithMany(p => p.JobTechnologies)
                .HasForeignKey(d => d.JobAnalysisId)
                .HasConstraintName("FK_dbo.JobTechnology_dbo.JobAnalysis_JobAnalysis_ID");
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Organization");

            entity.ToTable("Organization");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<Technology>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Technology");

            entity.ToTable("Technology");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<TrackMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.TrackMapping");

            entity.ToTable("TrackMapping");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
        });

        base.OnModelCreating(modelBuilder);
    }

   
}

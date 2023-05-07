using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IndustryExperienceMain.Models;

public partial class IndustryExperienceMainDbContext : DbContext
{
    public IndustryExperienceMainDbContext()
    {
    }

    public IndustryExperienceMainDbContext(DbContextOptions<IndustryExperienceMainDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agency> Agencies { get; set; }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=azureConString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agency>(entity =>
        {
            entity.HasKey(e => e.AgencyId).HasName("agency_pk");

            entity.ToTable("agency");

            entity.Property(e => e.AgencyId)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("agency_id");
            entity.Property(e => e.AgencyName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("agency_name");
            entity.Property(e => e.Link)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("link");
        });

        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Answer__3214EC07BC86BA17");

            entity.ToTable("Answer");

            entity.Property(e => e.Text).HasMaxLength(255);

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__Answer__Question__74AE54BC");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("job_pk");

            entity.ToTable("job");

            entity.Property(e => e.JobId)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("job_id");
            entity.Property(e => e.AgencyId)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("agency_id");
            entity.Property(e => e.Commitment)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("commitment");
            entity.Property(e => e.TimeSection)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("time_section");
            entity.Property(e => e.TypeOfWork)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type_of_work");
            entity.Property(e => e.Workplace)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("workplace");

            entity.HasOne(d => d.Agency).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.AgencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("job_id_fk1");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC075A2B3C4C");

            entity.ToTable("Question");

            entity.Property(e => e.Text).HasMaxLength(255);

            entity.HasOne(d => d.Quiz).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuizId)
                .HasConstraintName("FK__Question__QuizId__71D1E811");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Quiz__3214EC073C158D68");

            entity.ToTable("Quiz");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

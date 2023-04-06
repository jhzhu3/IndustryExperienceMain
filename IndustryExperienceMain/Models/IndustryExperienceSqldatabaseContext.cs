using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IndustryExperienceMain.Models;

public partial class IndustryExperienceSqldatabaseContext : DbContext
{
    public IndustryExperienceSqldatabaseContext()
    {
    }

    public IndustryExperienceSqldatabaseContext(DbContextOptions<IndustryExperienceSqldatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agency> Agencies { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

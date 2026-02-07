using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Db_First.Models;

public partial class SportsLeagueContext : DbContext
{
    public SportsLeagueContext()
    {
    }
    
    public SportsLeagueContext(DbContextOptions<SportsLeagueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coach> Coaches { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=SportsLeague;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coach>(entity =>
        {
            entity.HasKey(e => e.CoachId).HasName("PK__Coaches__F411D941BB7155D6");

            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(30);
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__Groups__149AF36A48052B13");

            entity.HasIndex(e => e.GroupName, "UQ__Groups__6EFCD434EDC230A3").IsUnique();

            entity.Property(e => e.GroupName).HasMaxLength(60);
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("PK__Players__4A4E74C8B09FC7A0");

            entity.ToTable(tb => tb.HasTrigger("Calculate_Player_Salary"));

            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(30);

            entity.HasOne(d => d.Team).WithMany(p => p.Players)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Player_Team");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__9C8A5B496C23E4E5");

            entity.Property(e => e.MatchTime).HasColumnType("datetime");
            entity.Property(e => e.TeamAid).HasColumnName("TeamAId");
            entity.Property(e => e.TeamBid).HasColumnName("TeamBId");

            entity.HasOne(d => d.Group).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_Group");

            entity.HasOne(d => d.TeamA).WithMany(p => p.ScheduleTeamAs)
                .HasForeignKey(d => d.TeamAid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_TeamA");

            entity.HasOne(d => d.TeamB).WithMany(p => p.ScheduleTeamBs)
                .HasForeignKey(d => d.TeamBid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_TeamB");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__Teams__123AE79940D78017");

            entity.HasIndex(e => e.TeamName, "UQ__Teams__4E21CAACD37DCD49").IsUnique();

            entity.Property(e => e.TeamName).HasMaxLength(60);

            entity.HasOne(d => d.Coach).WithMany(p => p.Teams)
                .HasForeignKey(d => d.CoachId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Team_Coach");

            entity.HasOne(d => d.Group).WithMany(p => p.Teams)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Team_Group");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

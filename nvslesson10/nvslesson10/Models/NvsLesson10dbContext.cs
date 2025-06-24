using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace nvslesson10.Models;

public partial class NvsLesson10dbContext : DbContext
{
    public NvsLesson10dbContext()
    {
    }

    public NvsLesson10dbContext(DbContextOptions<NvsLesson10dbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NvsCategory> Categories { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=USER\\SQLEXPRESS;Database=NvsLesson10db;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NvsCategory>(entity =>
        {
            entity.HasKey(e => e.CateId);

            entity.ToTable("Category");

            entity.Property(e => e.CateId)
                .ValueGeneratedNever()
                .HasColumnName("CateID");
            entity.Property(e => e.CateName).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NguyenVanSon_2310900090.Models;

public partial class NguyenVanSon2310900090Context : DbContext
{
    public NguyenVanSon2310900090Context()
    {
    }

    public NguyenVanSon2310900090Context(DbContextOptions<NguyenVanSon2310900090Context> options)
        : base(options)
    {
    }

    public virtual DbSet<NvsEmployee> NvsEmployees { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=USER\\SQLEXPRESS;Database=NguyenVanSon_2310900090;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NvsEmployee>(entity =>
        {
            entity.HasKey(e => e.NvsEmpId);

            entity.ToTable("NvsEmployee");

            entity.Property(e => e.NvsEmpId)
                .ValueGeneratedNever()
                .HasColumnName("nvsEmpId");
            entity.Property(e => e.NvsEmpLevel)
                .HasMaxLength(50)
                .HasColumnName("nvsEmpLevel");
            entity.Property(e => e.NvsEmpName)
                .HasMaxLength(50)
                .HasColumnName("nvsEmpName");
            entity.Property(e => e.NvsEmpStartDate).HasColumnName("nvsEmpStartDate");
            entity.Property(e => e.NvsEmpStatus).HasColumnName("nvsEmpStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

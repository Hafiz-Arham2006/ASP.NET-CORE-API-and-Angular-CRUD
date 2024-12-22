using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace crud_api.Models;

public partial class ApiCrudContext : DbContext
{
    public ApiCrudContext()
    {
    }

    public ApiCrudContext(DbContextOptions<ApiCrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-0AMODP1;database=api_crud;trusted_connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__students__3213E83FC21C16F7");

            entity.ToTable("students");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Class)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("class");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

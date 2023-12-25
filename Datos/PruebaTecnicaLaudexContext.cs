using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Datos;

public partial class PruebaTecnicaLaudexContext : DbContext
{
    public PruebaTecnicaLaudexContext()
    {
    }

    public PruebaTecnicaLaudexContext(DbContextOptions<PruebaTecnicaLaudexContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Prioridad> Prioridads { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database= PruebaTecnicaLaudex; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A10C3AB70B4");

            entity.Property(e => e.IdCategoria).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estado__FBB0EDC14ABE0FEC");

            entity.ToTable("Estado");

            entity.Property(e => e.IdEstado).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Prioridad>(entity =>
        {
            entity.HasKey(e => e.IdPrioridad).HasName("PK__Priorida__0FC70DD527667A2D");

            entity.ToTable("Prioridad");

            entity.Property(e => e.IdPrioridad).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__Tarea__EADE9098DACDEFF3");

            entity.ToTable("Tarea");

            entity.Property(e => e.IdTarea).ValueGeneratedOnAdd();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Tarea__IdCategor__3E52440B");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Tarea__IdEstado__3D5E1FD2");

            entity.HasOne(d => d.IdPrioridadNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdPrioridad)
                .HasConstraintName("FK__Tarea__IdPriorid__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

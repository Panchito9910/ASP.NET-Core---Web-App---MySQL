using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ModeloDualWebMySql.Models;

public partial class ModelodualContext : DbContext
{
    public ModelodualContext()
    {
    }

    public ModelodualContext(DbContextOptions<ModelodualContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql("server=localhost;port=3306;database=modelodual;uid=root;password=12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.24-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno).HasName("PRIMARY");

            entity.ToTable("alumnos");

            entity.HasIndex(e => e.Matricula, "matricula").IsUnique();

            entity.Property(e => e.IdAlumno)
                .HasColumnType("int(10)")
                .HasColumnName("id_alumno");
            entity.Property(e => e.ApellidoAlumno)
                .HasMaxLength(25)
                .HasColumnName("apellido_alumno");
            entity.Property(e => e.CorreoAlumno)
                .HasMaxLength(26)
                .HasColumnName("correo_alumno");
            entity.Property(e => e.Matricula)
                .HasMaxLength(9)
                .HasColumnName("matricula");
            entity.Property(e => e.NombreAlumno)
                .HasMaxLength(25)
                .HasColumnName("nombre_alumno");
            entity.Property(e => e.SemestreActual)
                .HasColumnType("int(1)")
                .HasColumnName("semestre_actual");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PRIMARY");

            entity.ToTable("empresas");

            entity.HasIndex(e => e.CodigoEmpresa, "codigo_empresa").IsUnique();

            entity.Property(e => e.IdEmpresa)
                .HasColumnType("int(11)")
                .HasColumnName("id_empresa");
            entity.Property(e => e.CodigoEmpresa)
                .HasMaxLength(10)
                .HasColumnName("codigo_empresa");
            entity.Property(e => e.CorreoEmpresa)
                .HasMaxLength(30)
                .HasColumnName("correo_empresa");
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(25)
                .HasColumnName("nombre_empresa");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.IdProyecto).HasName("PRIMARY");

            entity.ToTable("proyectos");

            entity.HasIndex(e => e.CodigoEmpresa, "codigo_empresa");

            entity.HasIndex(e => e.CodigoProyecto, "codigo_proyecto").IsUnique();

            entity.HasIndex(e => e.Matricula, "matricula").IsUnique();

            entity.Property(e => e.IdProyecto)
                .HasColumnType("int(11)")
                .HasColumnName("id_proyecto");
            entity.Property(e => e.CodigoEmpresa)
                .HasMaxLength(10)
                .HasColumnName("codigo_empresa");
            entity.Property(e => e.CodigoProyecto)
                .HasMaxLength(10)
                .HasColumnName("codigo_proyecto");
            entity.Property(e => e.Matricula)
                .HasMaxLength(9)
                .HasColumnName("matricula");
            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(30)
                .HasColumnName("nombre_proyecto");

            entity.HasOne(d => d.CodigoEmpresaNavigation).WithMany(p => p.Proyectos)
                .HasPrincipalKey(p => p.CodigoEmpresa)
                .HasForeignKey(d => d.CodigoEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proyectos_ibfk_1");

            entity.HasOne(d => d.MatriculaNavigation).WithMany(p => p.Proyectos)
               .HasPrincipalKey(p => p.Matricula)
               .HasForeignKey(d => d.Matricula)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("proyectos_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

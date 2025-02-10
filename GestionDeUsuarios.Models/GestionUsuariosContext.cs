using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestionDeUsuarios.Models;

public partial class GestionUsuariosContext : DbContext
{
    public GestionUsuariosContext()
    {
    }

    public GestionUsuariosContext(DbContextOptions<GestionUsuariosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuarios_pkey");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Username, "usuarios_username_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AltamenteRelevantes)
                .HasDefaultValue(0)
                .HasColumnName("altamente_relevantes");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.Pendientes)
                .HasDefaultValue(0)
                .HasColumnName("pendientes");
            entity.Property(e => e.TotalAsignados)
                .HasDefaultValue(0)
                .HasColumnName("total_asignados");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

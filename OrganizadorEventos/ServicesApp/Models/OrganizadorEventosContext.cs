using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrganizadorEventos.ServicesApp.Models;

public partial class OrganizadorEventosContext : DbContext
{
    public OrganizadorEventosContext()
    {
    }

    public OrganizadorEventosContext(DbContextOptions<OrganizadorEventosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<EquiposEvento> EquiposEventos { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Historial> Historials { get; set; }

    public virtual DbSet<MiembrosEquipo> MiembrosEquipos { get; set; }

    public virtual DbSet<ParticipanteEvento> ParticipanteEventos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-LBCR930N\\SQLEXPRESS;Initial Catalog=OrganizadorEventos;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.EquipoId).HasName("PK__Equipo__DE8A0BFF65128C91");

            entity.ToTable("Equipo");

            entity.Property(e => e.EquipoId).HasColumnName("EquipoID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RepresentanteId).HasColumnName("RepresentanteID");

            entity.HasOne(d => d.Representante).WithMany(p => p.Equipos)
                .HasForeignKey(d => d.RepresentanteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Equipo__Represen__1EA48E88");
        });

        modelBuilder.Entity<EquiposEvento>(entity =>
        {
            entity.HasKey(e => e.EquipoEventoId).HasName("PK__Equipos___FAE7951006F93652");

            entity.ToTable("Equipos_Evento");

            entity.HasOne(d => d.Equipo).WithMany(p => p.EquiposEventos)
                .HasForeignKey(d => d.EquipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Equipos_E__Equip__282DF8C2");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EventoId).HasName("PK__Evento__1EEB590158DA70CA");

            entity.ToTable("Evento");

            entity.Property(e => e.EventoId).HasColumnName("EventoID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Finalizacion).HasColumnType("date");
            entity.Property(e => e.Inicio).HasColumnType("date");
            entity.Property(e => e.LugarEvento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrganizadorId).HasColumnName("OrganizadorID");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Organizador).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.OrganizadorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Evento__Organiza__1BC821DD");
        });

        modelBuilder.Entity<Historial>(entity =>
        {
            entity.HasKey(e => e.HistorialId).HasName("PK__Historia__9752068FAC2FEAFB");

            entity.ToTable("Historial");

            entity.HasOne(d => d.Evento).WithMany(p => p.Historials)
                .HasForeignKey(d => d.EventoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historial__Event__22751F6C");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Historials)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historial__Usuar__2180FB33");
        });

        modelBuilder.Entity<MiembrosEquipo>(entity =>
        {
            entity.HasKey(e => e.MiembroEquipoId).HasName("PK__Miembros__5C016F2C0D24CF85");

            entity.ToTable("MiembrosEquipo");

            entity.Property(e => e.MiembroEquipoId).HasColumnName("MiembroEquipoID");
            entity.Property(e => e.EquipoId).HasColumnName("EquipoID");
            entity.Property(e => e.MiembroId).HasColumnName("MiembroID");

            entity.HasOne(d => d.Equipo).WithMany(p => p.MiembrosEquipos)
                .HasForeignKey(d => d.EquipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MiembrosE__Equip__2BFE89A6");

            entity.HasOne(d => d.Miembro).WithMany(p => p.MiembrosEquipos)
                .HasForeignKey(d => d.MiembroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MiembrosE__Miemb__2B0A656D");
        });

        modelBuilder.Entity<ParticipanteEvento>(entity =>
        {
            entity.HasKey(e => e.ParticipanteEventoId).HasName("PK__Particip__0DD45189D02C8D2A");

            entity.ToTable("Participante_Evento");

            entity.HasOne(d => d.Participante).WithMany(p => p.ParticipanteEventos)
                .HasForeignKey(d => d.ParticipanteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Participa__Parti__25518C17");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE7B81F42A4FA");

            entity.ToTable("Usuario");

            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contrasenha)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Organizacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EPSS.Models
{
    public partial class escuelapsdelsurContext : DbContext
    {
        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<Carreras> Carreras { get; set; }
        public virtual DbSet<CodigosPostales> CodigosPostales { get; set; }
        public virtual DbSet<Coordinaciones> Coordinaciones { get; set; }
        public virtual DbSet<Coordinadores> Coordinadores { get; set; }
        public virtual DbSet<CursosXxx> CursosXxx { get; set; }
        public virtual DbSet<Divisiones> Divisiones { get; set; }
        public virtual DbSet<EstadosDivision> EstadosDivision { get; set; }
        public virtual DbSet<Estudios> Estudios { get; set; }
        public virtual DbSet<Eventos> Eventos { get; set; }
        public virtual DbSet<GruposXxx> GruposXxx { get; set; }
        public virtual DbSet<Interesados> Interesados { get; set; }
        public virtual DbSet<InteresadosEventos> InteresadosEventos { get; set; }
        public virtual DbSet<Legajos> Legajos { get; set; }
        public virtual DbSet<Localidades> Localidades { get; set; }
        public virtual DbSet<Lugares> Lugares { get; set; }
        public virtual DbSet<MediosDeContacto> MediosDeContacto { get; set; }
        public virtual DbSet<Modalidades> Modalidades { get; set; }
        public virtual DbSet<Modos> Modos { get; set; }
        public virtual DbSet<NivelesEstudios> NivelesEstudios { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Partidos> Partidos { get; set; }
        public virtual DbSet<Provincias> Provincias { get; set; }
        public virtual DbSet<Trabajos> Trabajos { get; set; }
        public virtual DbSet<Turnos> Turnos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumnos>(entity =>
            {
                entity.Property(e => e.AlumnoId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Carreras>(entity =>
            {
                entity.Property(e => e.CarreraId).ValueGeneratedNever();
            });

            modelBuilder.Entity<CodigosPostales>(entity =>
            {
                entity.HasKey(e => new { e.PaisId, e.CodigoPostalId })
                    .HasName("PK_CodigosPostales");
            });

            modelBuilder.Entity<Coordinaciones>(entity =>
            {
                entity.HasKey(e => new { e.CarreraId, e.ModoId, e.CursoId, e.TurnoId, e.DivisionId, e.CoordinadorId })
                    .HasName("PK_Coordinaciones");
            });

            modelBuilder.Entity<Coordinadores>(entity =>
            {
                entity.Property(e => e.CoordinadorId).ValueGeneratedNever();
            });

            modelBuilder.Entity<CursosXxx>(entity =>
            {
                entity.HasKey(e => new { e.CarreraId, e.ModoId, e.CursoId })
                    .HasName("PK_CursosXXX");
            });

            modelBuilder.Entity<Divisiones>(entity =>
            {
                entity.HasKey(e => new { e.CarreraId, e.ModoId, e.CursoId, e.TurnoId, e.DivisionId })
                    .HasName("PK_Divisiones");
            });

            modelBuilder.Entity<Estudios>(entity =>
            {
                entity.HasKey(e => new { e.AlumnoId, e.EstudioId })
                    .HasName("PK_Estudios");
            });

            modelBuilder.Entity<GruposXxx>(entity =>
            {
                entity.HasKey(e => new { e.CarreraId, e.ModoId, e.CursoId, e.TurnoId, e.DivisionId, e.AlumnoId })
                    .HasName("PK_GruposXXX");
            });

            modelBuilder.Entity<Interesados>(entity =>
            {
                entity.Property(e => e.Seguimiento).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Legajos>(entity =>
            {
                entity.HasIndex(e => e.LegajoNro)
                    .HasName("IX_Legajos")
                    .IsUnique();

                entity.HasIndex(e => new { e.DireccionLocalidadId, e.DireccionPartidoId, e.DireccionProvinciaId, e.DireccionPaisId })
                    .HasName("IX_Localidad");

                entity.Property(e => e.FechaNacimiento).HasColumnType("smalldatetime");

                entity.Property(e => e.AlumnoId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Localidades>(entity =>
            {
                entity.HasKey(e => new { e.PaisId, e.ProvinciaId, e.PartidoD, e.LocalidadId })
                    .HasName("PK_Localidades");
            });

            modelBuilder.Entity<MediosDeContacto>(entity =>
            {
                entity.HasKey(e => e.MedioDeContactoId)
                    .HasName("PK_medios_contacto");
            });

            modelBuilder.Entity<Partidos>(entity =>
            {
                entity.HasKey(e => new { e.PaisId, e.ProvinciaId, e.PartidoId })
                    .HasName("PK_Partidos");
            });

            modelBuilder.Entity<Provincias>(entity =>
            {
                entity.HasKey(e => new { e.PaisId, e.ProvinciaId })
                    .HasName("PK_Provincias");
            });

            modelBuilder.Entity<Trabajos>(entity =>
            {
                entity.HasKey(e => new { e.AlumnoId, e.TrabajoId })
                    .HasName("PK_Trabajos");
            });
        }
    }
}
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class escuelapsdelsurContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Data Source=NB01\SQLEXPRESS;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=escuelapsdelsur;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CodigosPostales>(entity =>
            {
                entity.HasKey(e => new { e.PaisId, e.CodigoPostalId })
                    .HasName("PK_CodigoPostal_1");
            });

            modelBuilder.Entity<Coordinacion>(entity =>
            {
                entity.HasKey(e => new { e.PromocionId, e.CuatrimestreId, e.ModoId, e.TurnoId, e.CursoId, e.CoordinadorId })
                    .HasName("PK_Coordinacion");
            });

            modelBuilder.Entity<Coordinadores>(entity =>
            {
                entity.Property(e => e.CoordinadorId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.HasKey(e => new { e.PromocionId, e.CuatrimestreId, e.ModoId, e.TurnoId, e.CursoId })
                    .HasName("PK_Cursos");
            });

            modelBuilder.Entity<Estudios>(entity =>
            {
                entity.HasKey(e => new { e.AlumnoId, e.EstudioId })
                    .HasName("PK_Estudios");

                entity.HasIndex(e => e.AlumnoId)
                    .HasName("IX_Estudios");
            });

            modelBuilder.Entity<Grupos>(entity =>
            {
                entity.HasKey(e => new { e.PromocionId, e.CuatrimestreId, e.ModoId, e.TurnoId, e.CursoId, e.AlumnoId })
                    .HasName("PK_Grupos");
            });

            modelBuilder.Entity<Legajos>(entity =>
            {
                entity.HasIndex(e => e.LegajoNro)
                    .HasName("IX_Legajos")
                    .IsUnique();

                entity.HasIndex(e => new { e.DireccionLocalidadId, e.DireccionProvinciaId, e.DireccionPaisId })
                    .HasName("IX_Localidad");

                entity.Property(e => e.AlumnoId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Localidades>(entity =>
            {
                entity.HasKey(e => new { e.PaisId, e.ProvinciaId, e.PartidoD, e.LocalidadId })
                    .HasName("PK_Localidades_1");
            });

            modelBuilder.Entity<Partidos>(entity =>
            {
                entity.HasKey(e => new { e.PaisId, e.ProvinciaId, e.PartidoId })
                    .HasName("PK_Partidos");
            });

            modelBuilder.Entity<Promociones>(entity =>
            {
                entity.HasKey(e => new { e.PromocionId, e.CuatrimestreId, e.ModoId, e.TurnoId })
                    .HasName("PK_Promociones");
            });

            modelBuilder.Entity<Provincias>(entity =>
            {
                entity.HasKey(e => new { e.PaisId, e.ProvinciaId })
                    .HasName("PK_Provincias_1");
            });
        }

        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<CodigosPostales> CodigosPostales { get; set; }
        public virtual DbSet<Coordinacion> Coordinacion { get; set; }
        public virtual DbSet<Coordinadores> Coordinadores { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Estudios> Estudios { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<Legajos> Legajos { get; set; }
        public virtual DbSet<Localidades> Localidades { get; set; }
        public virtual DbSet<Modalidades> Modalidades { get; set; }
        public virtual DbSet<Modos> Modos { get; set; }
        public virtual DbSet<NivelesEstudios> NivelesEstudios { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Partidos> Partidos { get; set; }
        public virtual DbSet<Promociones> Promociones { get; set; }
        public virtual DbSet<Provincias> Provincias { get; set; }
        public virtual DbSet<Turnos> Turnos { get; set; }
    }
}
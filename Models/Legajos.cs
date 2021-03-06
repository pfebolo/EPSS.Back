﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class Legajos
    {
        public Legajos()
        {
            Estudios = new HashSet<Estudios>();
            Trabajos = new HashSet<Trabajos>();
            Grupos = new HashSet<Grupos>();
            Informes = new HashSet<Informes>();
            Interacciones = new HashSet<Interacciones>();
        }

        [Column("AlumnoID")]
        [Key]
        public int AlumnoId { get; set; }
        public int LegajoNro { get; set; }
        [Required]
        [Column(TypeName = "char(9)")]
        public string Sexo { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? FechaNacimiento { get; set; }
        [MaxLength(255)]
        public string LugarNacimiento { get; set; }
        [Column("DNI")]
        public int Dni { get; set; }
        [Column("CUIT", TypeName = "decimal")]
        public decimal? Cuit { get; set; }
        [Required]
        [MaxLength(255)]
        public string DireccionCalle { get; set; }
        [Required]
        [MaxLength(255)]
        public string DireccionNro { get; set; }
        [MaxLength(255)]
        public string DireccionCoordenadaInterna { get; set; }
        [Column("DireccionLocalidadID")]
        public int? DireccionLocalidadId { get; set; }
        [Column("DireccionPartidoID")]
        public int? DireccionPartidoId { get; set; }
        [Column("DireccionProvinciaID")]
        [MaxLength(50)]
        public string DireccionProvinciaId { get; set; }
        [Column("DireccionPaisID")]
        [MaxLength(50)]
        public string DireccionPaisId { get; set; }
        [Column("SecundarioCompletoOLey25")]
        public bool? SecundarioCompletoOley25 { get; set; }
        [MaxLength(255)]
        public string Comentarios { get; set; }
        public int? CodigoPostalBase { get; set; }
        [MaxLength(255)]
        public string LocalidadBase { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaIngreso { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PagoIniFecha { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string PagoIniMonto { get; set; }
        [MaxLength(50)]
        public string ModalidadBase { get; set; }
        [MaxLength(50)]
        public string Turno { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Cuestionario { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DocAptoFisico { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DocTitulo { get; set; }
        [Column("DocDNI", TypeName = "datetime")]
        public DateTime? DocDni { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DocFoto { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DocCompromiso { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DocAptoFisicoValido { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DocTituloValido { get; set; }
        [Column("DocDNIValido", TypeName = "datetime")]
        public DateTime? DocDnivalido { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DocFotoValido { get; set; }
        [MaxLength(1024)]
        public string PathFoto { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Historia { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Definicion { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Situacion { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Expectativas { get; set; }
        public int? LibroMatriz { get; set; }
        public int? Folio { get; set; }
        public bool Seguimiento { get; set; }
        [Required]
        [Column("EstadoEstudianteID")]
        [MaxLength(255)]
        public string EstadoEstudianteId { get; set; }
        [MaxLength(255)]
        public string RazonSuspension { get; set; }


        [ForeignKey("AlumnoId")]
        [InverseProperty("Legajos")]
        public virtual Alumnos Alumno { get; set; }

        [ForeignKey("EstadoEstudianteId")]
        [InverseProperty("Legajos")]
        public virtual EstadosEstudiante EstadoEstudiante { get; set; }

        [ForeignKey("DireccionPaisId,DireccionProvinciaId,DireccionPartidoId,DireccionLocalidadId")]
        [InverseProperty("Legajos")]
        public virtual Localidades Localidad { get; set; }

        [InverseProperty("Legajo")]
        public virtual ICollection<Estudios> Estudios { get; set; }

        [InverseProperty("Legajo")]
        public virtual ICollection<Trabajos> Trabajos { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Legajo")]
        public virtual ICollection<Grupos> Grupos { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Legajo")]
        public virtual ICollection<Interacciones> Interacciones { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Legajo")]
        public virtual ICollection<Informes> Informes { get; set; }
    }
}

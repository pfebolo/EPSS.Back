using System;
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
        [MaxLength(50)]
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
        [Column(TypeName = "varchar(max)")]
        public string Historia { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Definicion { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Situacion { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string Expectativas { get; set; }





        [ForeignKey("AlumnoId")]
        [InverseProperty("Legajos")]
        public virtual Alumnos Alumno { get; set; }
        
        [ForeignKey("DireccionPaisId,DireccionProvinciaId,DireccionPartidoId,DireccionLocalidadId")]
        [InverseProperty("Legajos")]
        public virtual Localidades Localidad { get; set; }

        [InverseProperty("Legajo")]
        public virtual ICollection<Estudios> Estudios { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Legajo")]
        public virtual ICollection<Grupos> Grupos { get; set; }

        [InverseProperty("Legajo")]
        public virtual ICollection<Trabajos> Trabajos { get; set; }
    }
}

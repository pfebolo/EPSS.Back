using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public partial class Legajos
    {
        [Column("AlumnoID")]
        [Key]
        public int AlumnoId { get; set; }
        public int LegajoNro { get; set; }
        [Required]
        [Column(TypeName = "char(9)")]
        public string Sexo { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime FechaNacimiento { get; set; }
        [MaxLength(50)]
        public string LugarNacimiento { get; set; }
        [Column("DNI")]
        public int Dni { get; set; }
        [Column("CUIT")]
        public int? Cuit { get; set; }
        [Required]
        [MaxLength(255)]
        public string DireccionCalle { get; set; }
        [Required]
        [MaxLength(255)]
        public string DireccionNro { get; set; }
        [MaxLength(255)]
        public string DireccionCoordenadaInterna { get; set; }
        [Column("DireccionLocalidadID")]
        public int DireccionLocalidadId { get; set; }
        [Column("DireccionPartidoID")]
        public int DireccionPartidoId { get; set; }
        [Required]
        [Column("DireccionProvinciaID")]
        [MaxLength(50)]
        public string DireccionProvinciaId { get; set; }
        [Required]
        [Column("DireccionPaisID")]
        [MaxLength(50)]
        public string DireccionPaisId { get; set; }
        [Column("SecundarioCompletoOLey25")]
        public bool SecundarioCompletoOley25 { get; set; }
        [MaxLength(255)]
        public string Comentarios { get; set; }

        [ForeignKey("AlumnoId")]
        [InverseProperty("Legajos")]
        public virtual Alumnos Alumno { get; set; }
        [ForeignKey("DireccionPaisId,DireccionProvinciaId,DireccionPartidoId,DireccionLocalidadId")]
        [InverseProperty("Legajos")]
        public virtual Localidades Direccion { get; set; }
    }
}

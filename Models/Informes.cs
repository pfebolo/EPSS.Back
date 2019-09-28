using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPSS.Models
{
    public partial class Informes
    {
        [Column("AlumnoID")]
        public int AlumnoId { get; set; }
        [Column("InformeID")]
        public int InformeId { get; set; }
        public short AnioLectivo { get; set; }
        [Column("CoordinadorID")]
        public int CoordinadorId { get; set; }
        [Required]
        public string Informe { get; set; }
        public DateTimeOffset FechaCreacion { get; set; }
        public DateTimeOffset FechaActualizacion { get; set; }

        [ForeignKey("AlumnoId")]
        [InverseProperty("Informes")]
        public virtual Legajos Legajo { get; set; }
        [ForeignKey("CoordinadorId")]
        [InverseProperty("Informes")]
        public virtual Coordinadores Coordinador { get; set; }
    }
}

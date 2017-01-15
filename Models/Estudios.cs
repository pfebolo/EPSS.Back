using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class Estudios
    {


        [Column("AlumnoID")]
        public int AlumnoId { get; set; }
        [Column("EstudioID")]
        public int EstudioId { get; set; }
        [Required]
        [Column("NivelEstudioID")]
        [MaxLength(50)]
        public string NivelEstudioId { get; set; }
        public bool Terminado { get; set; }
        [Required]
        [MaxLength(255)]
        public string Titulo { get; set; }
        [Required]
        [MaxLength(255)]
        public string Institucion { get; set; }

        [IgnoreDataMember]
        [ForeignKey("AlumnoId")]
        [InverseProperty("Estudios")]
        public virtual Legajos Legajo { get; set; }

        
        [ForeignKey("NivelEstudioId")]
        [InverseProperty("Estudios")]
        public virtual NivelesEstudios NivelEstudio { get; set; }
    }
}

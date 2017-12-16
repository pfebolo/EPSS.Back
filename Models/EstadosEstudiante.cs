using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class EstadosEstudiante
    {
        public EstadosEstudiante()
        {
            Legajos = new HashSet<Legajos>();
        }

        [Column("EstadoEstudianteID")]
        [MaxLength(255)]
        [Key]
        public string EstadoEstudianteId { get; set; }
        public bool ActaVolante { get; set; }

        [IgnoreDataMember]
        [InverseProperty("EstadoEstudiante")]
        public virtual ICollection<Legajos> Legajos { get; set; }
    }
}

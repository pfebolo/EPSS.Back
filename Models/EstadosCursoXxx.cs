using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    [Table("EstadosCursoXXX")]
    public partial class EstadosCursoXxx
    {
        public EstadosCursoXxx()
        {
            Divisiones = new HashSet<Divisiones>();
        }

        [Column("EstadoCursoID")]
        [MaxLength(25)]
        [Key]
        public string EstadoCursoId { get; set; }

		[IgnoreDataMember]        
		[InverseProperty("EstadoCurso")]
        public virtual ICollection<Divisiones> Divisiones { get; set; }
    }
}

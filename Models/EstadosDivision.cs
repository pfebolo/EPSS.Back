using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class EstadosDivision
    {
        public EstadosDivision()
        {
            Divisiones = new HashSet<Divisiones>();
        }

        [Column("EstadoDivisionID")]
        [MaxLength(25)]
        [Key]
        public string EstadoDivisionId { get; set; }

		[IgnoreDataMember]
        [InverseProperty("EstadoDivision")]
        public virtual ICollection<Divisiones> Divisiones { get; set; }
    }
}

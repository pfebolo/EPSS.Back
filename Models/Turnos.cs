using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class Turnos
    {
        public Turnos()
        {
            Divisiones = new HashSet<Divisiones>();
            Promociones = new HashSet<Promociones>();
        }

        [Column("TurnoID")]
        [MaxLength(25)]
        [Key]
        public string TurnoId { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Turno")]
        public virtual ICollection<Divisiones> Divisiones { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Turno")]
        public virtual ICollection<Promociones> Promociones { get; set; }
    }
}

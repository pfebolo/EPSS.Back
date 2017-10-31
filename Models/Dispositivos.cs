using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class Dispositivos
    {
        public Dispositivos()
        {
            Coordinaciones = new HashSet<Coordinaciones>();
        }

        [Column("ModoID")]
        [MaxLength(25)]
        public string ModoId { get; set; }
        [Column("DispositivoID")]
        [MaxLength(50)]
        public string DispositivoId { get; set; }

		[IgnoreDataMember]
        [InverseProperty("Dispositivos")]
        public virtual ICollection<Coordinaciones> Coordinaciones { get; set; }

        [IgnoreDataMember] //No tiene sentido (tabla Modos es de tipo enumerado)
        [ForeignKey("ModoId")]
        [InverseProperty("Dispositivos")]
        public virtual Modos Modo { get; set; }
    }
}

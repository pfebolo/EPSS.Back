using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class MediosDeContacto
    {
        public MediosDeContacto()
        {
            Interesados = new HashSet<Interesados>();
        }

        [Column("medioDeContactoId")]
        public int MedioDeContactoId { get; set; }
        [Column("nombre")]
        [MaxLength(500)]
        public string Nombre { get; set; }

        [IgnoreDataMember]
        [InverseProperty("MedioDeContacto")]
        public virtual ICollection<Interesados> Interesados { get; set; }
    }
}

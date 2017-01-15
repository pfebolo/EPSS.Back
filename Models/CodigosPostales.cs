using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class CodigosPostales
    {
        public CodigosPostales()
        {
            Localidades = new HashSet<Localidades>();
        }

        [Column("PaisID")]
        [MaxLength(50)]
        public string PaisId { get; set; }
        [Column("CodigoPostalID")]
        public int CodigoPostalId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Codigo { get; set; }

        [IgnoreDataMember]
        [InverseProperty("CodigoPostal")]
        public virtual ICollection<Localidades> Localidades { get; set; }
        
        [ForeignKey("PaisId")]
        [InverseProperty("CodigosPostales")]
        public virtual Paises Pais { get; set; }
    }
}

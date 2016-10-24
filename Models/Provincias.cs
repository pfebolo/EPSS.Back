using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace API.Models
{
    public partial class Provincias
    {
        public Provincias()
        {
            Partidos = new HashSet<Partidos>();
        }

        [Column("PaisID")]
        [MaxLength(50)]
        public string PaisId { get; set; }
        [Column("ProvinciaID")]
        [MaxLength(50)]
        public string ProvinciaId { get; set; }

        [IgnoreDataMember]
        [InverseProperty("P")]
        public virtual ICollection<Partidos> Partidos { get; set; }
        
        [ForeignKey("PaisId")]
        [InverseProperty("Provincias")]
        public virtual Paises Pais { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class Partidos
    {
        public Partidos()
        {
            Localidades = new HashSet<Localidades>();
        }

        [Column("PaisID")]
        [MaxLength(50)]
        public string PaisId { get; set; }
        [Column("ProvinciaID")]
        [MaxLength(50)]
        public string ProvinciaId { get; set; }
        [Column("PartidoID")]
        public int PartidoId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Partido")]
        public virtual ICollection<Localidades> Localidades { get; set; }
        
        [ForeignKey("PaisId,ProvinciaId")]
        [InverseProperty("Partidos")]
        public virtual Provincias Provincia { get; set; }
    }
}

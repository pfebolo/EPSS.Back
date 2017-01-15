using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class Localidades
    {
        public Localidades()
        {
            Legajos = new HashSet<Legajos>();
        }

        [Column("PaisID")]
        [MaxLength(50)]
        public string PaisId { get; set; }
        [Column("ProvinciaID")]
        [MaxLength(50)]
        public string ProvinciaId { get; set; }
        public int PartidoD { get; set; }
        [Column("LocalidadID")]
        public int LocalidadId { get; set; }
        [Column("CodigoPostalID")]
        public int CodigoPostalId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Localidad")]
        public virtual ICollection<Legajos> Legajos { get; set; }
        
        [ForeignKey("PaisId,CodigoPostalId")]
        [InverseProperty("Localidades")]
        public virtual CodigosPostales CodigoPostal { get; set; }
        
        [ForeignKey("PaisId,ProvinciaId,PartidoD")]
        [InverseProperty("Localidades")]
        public virtual Partidos Partido { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class Coordinadores
    {
        public Coordinadores()
        {
            Coordinaciones = new HashSet<Coordinaciones>();
            Informes = new HashSet<Informes>();
        }

        [Column("CoordinadorID")]
        [Key]
        public int CoordinadorId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }
        public string FotoPath { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? TelefonoFijo { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? TelefonoCelular { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }
        [MaxLength(255)]
        public string Comentarios { get; set; }
        public bool Activo { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Coordinador")]
        public virtual ICollection<Coordinaciones> Coordinaciones { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Coordinador")]
        public virtual ICollection<Informes> Informes { get; set; }
    }
}

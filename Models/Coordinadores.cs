using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace API.Models
{
    public partial class Coordinadores
    {
        public Coordinadores()
        {
            Coordinaciones = new HashSet<Coordinacion>();
        }

        [Column("CoordinadorID")]
        [Key]
        public int CoordinadorId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }
        public string FotoPath { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Coordinador")]
        public virtual ICollection<Coordinacion> Coordinaciones { get; set; }
    }
}

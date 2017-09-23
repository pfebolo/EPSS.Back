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
            Coordinaciones = new HashSet<Coordinacion>();
            CoordinacionesXxx = new HashSet<Coordinaciones>();
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

        [IgnoreDataMember]
        [InverseProperty("Coordinador")]
        public virtual ICollection<Coordinacion> Coordinaciones { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Coordinador")]
        public virtual ICollection<Coordinaciones> CoordinacionesXxx { get; set; }
    }
}

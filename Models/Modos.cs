using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class Modos
    {
        public Modos()
        {
            CursosXxx = new HashSet<CursosXxx>();
            Promociones = new HashSet<Promociones>();
        }

        [Column("ModoID")]
        [MaxLength(25)]
        [Key]
        public string ModoId { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Modo")]
        public virtual ICollection<CursosXxx> CursosXxx { get; set; }
        
        [IgnoreDataMember]        
        [InverseProperty("Modo")]
        public virtual ICollection<Promociones> Promociones { get; set; }
    }
}

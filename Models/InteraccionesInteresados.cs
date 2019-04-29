using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPSS.Models
{
    public partial class InteraccionesInteresados
    {
        public int InteresadoId { get; set; }
        public int InteraccionInteresadoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public int? PadreId { get; set; }

        [ForeignKey("InteresadoId")]
        [InverseProperty("InteraccionesInteresados")]
        public virtual Interesados Interesado { get; set; }


        [ForeignKey("InteraccionInteresadoId,PadreId")]
        [InverseProperty("InverseInteraccionesInteresadosNavigation")]
        public virtual InteraccionesInteresados InteraccionesInteresadosNavigation { get; set; }
        
        [InverseProperty("InteraccionesInteresadosNavigation")]
        public virtual ICollection<InteraccionesInteresados> InverseInteraccionesInteresadosNavigation { get; set; }
    }
}

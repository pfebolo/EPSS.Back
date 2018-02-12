using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPSS.Models
{
    public partial class Interacciones
    {
        [Column("AlumnoID")]
        public int AlumnoId { get; set; }
        public int InteraccionId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        [Column("PadreID")]
        public int? PadreId { get; set; }

        [ForeignKey("AlumnoId")]
        [InverseProperty("Interacciones")]
        public virtual Legajos Legajo { get; set; }




        [ForeignKey("AlumnoId,PadreId")]
        [InverseProperty("InverseInteraccionesNavigation")]
        public virtual Interacciones InteraccionesNavigation { get; set; }

        
        [InverseProperty("InteraccionesNavigation")]
        public virtual ICollection<Interacciones> InverseInteraccionesNavigation { get; set; }
    }
}

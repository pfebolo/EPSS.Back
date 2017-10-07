using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPSS.Models
{
    public partial class Coordinaciones
    {
        [Column("CarreraID")]
        public int CarreraId { get; set; }
        [Column("ModoID")]
        [MaxLength(25)]
        public string ModoId { get; set; }
        [Column("CursoID")]
        public int CursoId { get; set; }
        [Column("TurnoID")]
        [MaxLength(25)]
        public string TurnoId { get; set; }
        [Column("DivisionID")]
        [MaxLength(2)]
        public string DivisionId { get; set; }
        [Column("CoordinadorID")]
        public int CoordinadorId { get; set; }
        [MaxLength(255)]
        public string Comentario { get; set; }

        [ForeignKey("CoordinadorId")]
        [InverseProperty("Coordinaciones")]
        public virtual Coordinadores Coordinador { get; set; }
        
        [ForeignKey("CarreraId,ModoId,CursoId,TurnoId,DivisionId")]
        [InverseProperty("Coordinaciones")]
        public virtual Divisiones Divisiones { get; set; }
    }
}

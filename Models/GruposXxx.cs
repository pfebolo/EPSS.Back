using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPSS.Models
{
    [Table("Grupos")]
    public partial class Grupos
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
        [Column("AlumnoID")]
        public int AlumnoId { get; set; }
        [MaxLength(255)]
        public string Comentario { get; set; }

        [ForeignKey("AlumnoId")]
        [InverseProperty("Grupos")]
        public virtual Legajos Legajo { get; set; }
        
        [ForeignKey("CarreraId,ModoId,CursoId,TurnoId,DivisionId")]
        [InverseProperty("Grupos")]
        public virtual Divisiones Division { get; set; }
    }
}

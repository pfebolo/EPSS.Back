﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class Grupos
    {
        [Column("PromocionID")]
        public int PromocionId { get; set; }
        [Column("CuatrimestreID")]
        public int CuatrimestreId { get; set; }
        [Column("ModoID")]
        [MaxLength(25)]
        public string ModoId { get; set; }
        [Column("TurnoID")]
        [MaxLength(25)]
        public string TurnoId { get; set; }
        [Column("CursoID")]
        public int CursoId { get; set; }
        [Column("AlumnoID")]
        public int AlumnoId { get; set; }


        [ForeignKey("AlumnoId")]
        [InverseProperty("Grupos")]
        public virtual Legajos Legajo { get; set; }

        [IgnoreDataMember]
        [ForeignKey("PromocionId,CuatrimestreId,ModoId,TurnoId,CursoId")]
        [InverseProperty("Grupos")]
        public virtual Cursos Curso { get; set; }
    }
}

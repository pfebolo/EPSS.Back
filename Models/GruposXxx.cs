﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPSS.Models
{
    [Table("GruposXXX")]
    public partial class GruposXxx
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
        public int DivisionId { get; set; }
        [Column("AlumnoID")]
        public int AlumnoId { get; set; }
        [MaxLength(255)]
        public string Comentario { get; set; }

        [ForeignKey("AlumnoId")]
        [InverseProperty("GruposXxx")]
        public virtual Legajos Alumno { get; set; }
        
        [ForeignKey("CarreraId,ModoId,CursoId,TurnoId,DivisionId")]
        [InverseProperty("GruposXxx")]
        public virtual Divisiones Divisiones { get; set; }
    }
}

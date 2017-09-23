﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPSS.Models
{
    [Table("CursosXXX")]
    public partial class CursosXxx
    {
        public CursosXxx()
        {
            Divisiones = new HashSet<Divisiones>();
        }

        [Column("CarreraID")]
        public int CarreraId { get; set; }
        [Column("ModoID")]
        [MaxLength(25)]
        public string ModoId { get; set; }
        [Column("CursoID")]
        public int CursoId { get; set; }
        public int MesInicio { get; set; }
        public int MesFinal { get; set; }
        public int AnioLectivo { get; set; }
        [Column("NMestreLectivo")]
        public int NmestreLectivo { get; set; }
        [MaxLength(255)]
        public string Comentario { get; set; }

        [InverseProperty("CursosXxx")]
        public virtual ICollection<Divisiones> Divisiones { get; set; }
        [ForeignKey("CarreraId")]
        [InverseProperty("Cursos")]
        public virtual Carreras Carrera { get; set; }
        [ForeignKey("ModoId")]
        [InverseProperty("CursosXxx")]
        public virtual Modos Modo { get; set; }
    }
}

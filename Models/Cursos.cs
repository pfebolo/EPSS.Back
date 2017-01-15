using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class Cursos
    {
        public Cursos()
        {
            Coordinaciones = new HashSet<Coordinacion>();
            Grupos = new HashSet<Grupos>();
        }

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
        [Column("EstadoCursoID")]
        public int EstadoCursoId { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Curso")]
        public virtual ICollection<Coordinacion> Coordinaciones { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Curso")]
        public virtual ICollection<Grupos> Grupos { get; set; }

        [IgnoreDataMember]
        [ForeignKey("PromocionId,CuatrimestreId,ModoId,TurnoId")]
        [InverseProperty("Cursos")]
        public virtual Promociones Promocion { get; set; }

        
        [ForeignKey("EstadoCursoId")]
        [InverseProperty("Cursos")]
        public virtual EstadosCurso EstadoCurso { get; set; }

    }
}

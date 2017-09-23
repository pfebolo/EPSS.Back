using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class Divisiones
    {
        public Divisiones()
        {
            Coordinaciones = new HashSet<Coordinaciones>();
            GruposXxx = new HashSet<GruposXxx>();
        }

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
        [Column("EstadoCursoID")]
        public int EstadoCursoId { get; set; }
        [MaxLength(255)]
        public string Comentario { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Divisiones")]
        public virtual ICollection<Coordinaciones> Coordinaciones { get; set; }
        
        [IgnoreDataMember]
        [InverseProperty("Divisiones")]
        public virtual ICollection<GruposXxx> GruposXxx { get; set; }
        
        [ForeignKey("EstadoCursoId")]
        [InverseProperty("Divisiones")]
        public virtual EstadosCurso EstadoCurso { get; set; }
        
        [ForeignKey("TurnoId")]
        [InverseProperty("Divisiones")]
        public virtual Turnos Turno { get; set; }
        
        [ForeignKey("CarreraId,ModoId,CursoId")]
        [InverseProperty("Divisiones")]
        public virtual CursosXxx CursosXxx { get; set; }
    }
}

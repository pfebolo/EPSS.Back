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
            Grupos = new HashSet<Grupos>();
        }

        [Column("CarreraID")]
        public int CarreraId { get; set; }
        [Column("ModoID")]
        [MaxLength(25)]
        public string ModoId { get; set; }
        public int AnioInicio { get; set; }
        public int MesInicio { get; set; }
        public int AnioLectivo { get; set; }
        [Column("NMestreLectivo")]
        public int NmestreLectivo { get; set; }
        [Column("TurnoID")]
        [MaxLength(25)]
        public string TurnoId { get; set; }
        [Column("DivisionID")]
        [MaxLength(2)]
        public string DivisionId { get; set; }
        [Required]
        [Column("EstadoDivisionID")]
        [MaxLength(25)]
        public string EstadoDivisionId { get; set; }
        [MaxLength(255)]
        public string Comentario { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Division")]
        public virtual ICollection<Coordinaciones> Coordinaciones { get; set; }
        
        [IgnoreDataMember]
        [InverseProperty("Division")]
        public virtual ICollection<Grupos> Grupos { get; set; }
        
        [IgnoreDataMember] //Enumerado
        [ForeignKey("EstadoDivisionId")]
        [InverseProperty("Divisiones")]
        public virtual EstadosDivision EstadoDivision { get; set; }
        
        [IgnoreDataMember] //Enumerado
        [ForeignKey("TurnoId")]
        [InverseProperty("Divisiones")]
        public virtual Turnos Turno { get; set; }

        [ForeignKey("CarreraId,ModoId,AnioInicio,MesInicio,AnioLectivo,NmestreLectivo")]
        [InverseProperty("Divisiones")]
        public virtual Cursos Curso { get; set; }
    }
}

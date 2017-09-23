
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class Promociones
    {
        public Promociones()
        {
            Cursos = new HashSet<Cursos>();
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
        public int MesFinal { get; set; }
        public int AnioLectivo { get; set; }
        [Column("nMestreLectivo")]
        public int NMestreLectivo { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Promocion")]
        public virtual ICollection<Cursos> Cursos { get; set; }

        [IgnoreDataMember]
        [ForeignKey("ModoId")]
        [InverseProperty("Promociones")]
        public virtual Modos Modo { get; set; }

        [IgnoreDataMember]
        [ForeignKey("TurnoId")]
        [InverseProperty("Promociones")]
        public virtual Turnos Turno { get; set; }
    }
}

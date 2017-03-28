using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class Coordinacion //TODO: Renombar Modelo Coordinacion x Coordinaciones
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
        [Column("CoordinadorID")]
        public int CoordinadorId { get; set; }

        [ForeignKey("CoordinadorId")]
        [InverseProperty("Coordinaciones")]
        public virtual Coordinadores Coordinador { get; set; }

        [IgnoreDataMember]
        [ForeignKey("PromocionId,CuatrimestreId,ModoId,TurnoId,CursoId")]
        [InverseProperty("Coordinaciones")]
        public virtual Cursos Curso { get; set; }
    }
}

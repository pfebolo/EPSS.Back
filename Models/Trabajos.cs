using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class Trabajos
    {
        [Column("AlumnoID")]
        public int AlumnoId { get; set; }
        [Column("TrabajoID")]
        public int TrabajoId { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string RazonSocial { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Cargo { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Antiguedad { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Telefono { get; set; }

        [IgnoreDataMember]
        [ForeignKey("AlumnoId")]
        [InverseProperty("Trabajos")]
        public virtual Legajos Legajo { get; set; }
    }
}

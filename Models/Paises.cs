using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class Paises
    {
        public Paises()
        {
            Alumnos = new HashSet<Alumnos>();
            CodigosPostales = new HashSet<CodigosPostales>();
            Provincias = new HashSet<Provincias>();
        }

        [Column("PaisID")]
        [MaxLength(50)]
        [Key]
        public string PaisId { get; set; }
        [Column(TypeName = "nchar(10)")]
        public string DescripcionPoliticaNivel2 { get; set; }
        [Column(TypeName = "nchar(10)")]
        public string DescripcionPoliticaNivel3 { get; set; }
        [Column(TypeName = "nchar(10)")]
        public string PatronCodigoPostal { get; set; }
        [MaxLength(50)]
        public string Nacionalidad { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Pais")]
        public virtual ICollection<CodigosPostales> CodigosPostales { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Pais")]
        public virtual ICollection<Provincias> Provincias { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Nacionalidad")]
        public virtual ICollection<Alumnos> Alumnos { get; set; }
    }
}

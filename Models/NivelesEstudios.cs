using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace API.Models
{
    public partial class NivelesEstudios
    {
        public NivelesEstudios()
        {
            Estudios = new HashSet<Estudios>();
        }

        [Column("NivelEstudioID")]
        [MaxLength(50)]
        [Key]
        public string NivelEstudioId { get; set; }

        [IgnoreDataMember]
        [InverseProperty("NivelEstudio")]
        public virtual ICollection<Estudios> Estudios { get; set; }
    }
}

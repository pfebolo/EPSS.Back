using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class Modos
    {
        public Modos()
        {
            Cursos = new HashSet<Cursos>();
            Dispositivos = new HashSet<Dispositivos>();
        }

        [Column("ModoID")]
        [MaxLength(25)]
        [Key]
        public string ModoId { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Modo")]
        public virtual ICollection<Cursos> Cursos { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Modo")]
        public virtual ICollection<Dispositivos> Dispositivos { get; set; }
    }
}

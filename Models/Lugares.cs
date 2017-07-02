using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace EPSS.Models
{
    [Table("lugares")]
    public partial class Lugares
    {
        public Lugares()
        {
            Eventos = new HashSet<Eventos>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Column("nombre", TypeName = "varchar(500)")]
        public string Nombre { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Lugar")]
        public virtual ICollection<Eventos> Eventos { get; set; }
    }
}

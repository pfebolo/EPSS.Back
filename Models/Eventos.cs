using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    [Table("eventos")]
    public partial class Eventos
    {
        public Eventos()
        {
            InteresadosEventos = new HashSet<InteresadosEventos>();
        }

        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column("fecha", TypeName = "date")]
        public DateTime? Fecha { get; set; }
        [Column("tipo_id")]
        public int? TipoId { get; set; }
        [Column("titulo", TypeName = "varchar(200)")]
        public string Titulo { get; set; }
        [Column("lugar_id")]
        public int? LugarId { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Evento")]        
        public virtual ICollection<InteresadosEventos> InteresadosEventos { get; set; }
        [ForeignKey("LugarId")]
        [InverseProperty("Eventos")]
        public virtual Lugares Lugar { get; set; }
    }
}

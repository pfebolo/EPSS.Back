using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPSS.Models
{
    [Table("interesados_eventos")]
    public partial class InteresadosEventos
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column("interesado_id")]
        public int? InteresadoId { get; set; }
        [Column("evento_id")]
        public int? EventoId { get; set; }
        [Column("observacion", TypeName = "varchar(1500)")]
        public string Observacion { get; set; }
        [Column("inscripto")]
        public bool? Inscripto { get; set; }
        [Column("asistente")]
        public bool? Asistente { get; set; }

        [ForeignKey("EventoId")]
        [InverseProperty("InteresadosEventos")]
        public virtual Eventos Evento { get; set; }

        
        [ForeignKey("InteresadoId")]
        public virtual Interesados Interesado { get; set; }

    }
}

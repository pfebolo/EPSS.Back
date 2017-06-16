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
        public virtual Eventos Evento { get; set; }
        [ForeignKey("interesado_id")]
        public virtual Interesados Interesado { get; set; }

    }
}

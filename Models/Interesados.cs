﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    [Table("interesados")]
    public partial class Interesados
    {
        [Column("id")]
        [Key]
        public int InteresadoId { get; set; }
        [Column("nombre", TypeName = "varchar(100)")]
        public string Nombre { get; set; }
        [Column("apellido", TypeName = "varchar(120)")]
        public string Apellido { get; set; }
        [Column("mail", TypeName = "varchar(150)")]
        public string Mail { get; set; }
        [Column("mail2", TypeName = "varchar(150)")]
        public string Mail2 { get; set; }
        [Column("telefono", TypeName = "varchar(25)")]
        public string Telefono { get; set; }
        [Column("celular", TypeName = "varchar(25)")]
        public string Celular { get; set; }
        [Column("como_conocio", TypeName = "varchar(100)")]
        public string ComoConocio { get; set; }
        [Column("modalidad_id")]
        public int? ModalidadId { get; set; }
        [Column("grado_interes", TypeName = "varchar(50)")]
        public string GradoInteres { get; set; }
        [Column("fecha_interesado", TypeName = "date")]
        public DateTime? FechaInteresado { get; set; }
        [Column("comentario", TypeName = "varchar(1500)")]
        public string Comentario { get; set; }
        [Column("provincia", TypeName = "varchar(70)")]
        public string Provincia { get; set; }
        [Column("situacion_inscripcion", TypeName = "varchar(200)")]
        public string SituacionInscripcion { get; set; }
        [Column("situacion_especial", TypeName = "varchar(200)")]
        public string SituacionEspecial { get; set; }
        [Column("CarreraID")]
        public int? CarreraId { get; set; }
        [Column("AnioACursar")]
        public int? AnioAcursar { get; set; }
        [Column("NMestreACursar")]
        public int? NmestreAcursar { get; set; }
        [Column(TypeName = "varchar(6)")]
        public string Turno { get; set; }
        public bool Seguimiento { get; set; }
        [Column("MedioDeContactoID")]
        public int? MedioDeContactoId { get; set; }
        public DateTimeOffset FechaActualizacion { get; set; }

        [ForeignKey("CarreraId")]
        [InverseProperty("Interesados")]
        public virtual Carreras Carrera { get; set; }
        
        [ForeignKey("MedioDeContactoId")]
        [InverseProperty("Interesados")]
        public virtual MediosDeContacto MedioDeContacto { get; set; }

        [ForeignKey("ModalidadId")]
        [InverseProperty("Interesados")]
        public virtual Modalidades Modalidad { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Interesado")]
        public virtual ICollection<InteraccionesInteresados> InteraccionesInteresados { get; set; }


    }
}

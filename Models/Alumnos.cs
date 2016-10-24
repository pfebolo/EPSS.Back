﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("alumnos")]
    public partial class Alumnos
    {
        [Column("id")]
        public int Id { get; set; }
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
        [Column("dni", TypeName = "varchar(100)")]
        public string Dni { get; set; }
        [Column("domicilio", TypeName = "varchar(500)")]
        public string Domicilio { get; set; }

        [InverseProperty("Alumno")]
        public virtual Legajos Legajos { get; set; }
        [ForeignKey("ModalidadId")]
        [InverseProperty("Alumnos")]
        public virtual Modalidades Modalidad { get; set; }
    }
}

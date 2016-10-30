﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace API.Models
{
    [Table("modalidades")]
    public partial class Modalidades
    {
        public Modalidades()
        {
            Alumnos = new HashSet<Alumnos>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Column("nombre", TypeName = "varchar(500)")]
        public string Nombre { get; set; }

         [IgnoreDataMember]
        [InverseProperty("Modalidad")]
        public virtual ICollection<Alumnos> Alumnos { get; set; }
    }
}
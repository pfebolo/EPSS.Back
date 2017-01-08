﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace API.Models
{
    public partial class Turnos
    {
        public Turnos()
        {
            Promociones = new HashSet<Promociones>();
        }

        [Column("TurnoID")]
        [MaxLength(25)]
        [Key]
        public string TurnoId { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Turno")]
        public virtual ICollection<Promociones> Promociones { get; set; }
    }
}
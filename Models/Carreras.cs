using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
    public partial class Carreras
    {
        public Carreras()
        {
            Alumnos = new HashSet<Alumnos>();
            Cursos = new HashSet<Cursos>();
            Interesados = new HashSet<Interesados>();
        }

        [Column("CarreraID")]
        [Key]
        public int CarreraId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Descripcion { get; set; }
        [MaxLength(255)]
        public string Resolucion { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Carrera")]
        public virtual ICollection<Alumnos> Alumnos { get; set; }

		[IgnoreDataMember]
        [InverseProperty("Carrera")]
        public virtual ICollection<Cursos> Cursos { get; set; }

		[IgnoreDataMember]
		[InverseProperty("Carrera")]
		public virtual ICollection<Interesados> Interesados { get; set; }
	}
}

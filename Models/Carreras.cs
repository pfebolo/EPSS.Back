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
			Interesados = new HashSet<Interesados>();
		}

		[Column("CarreraID")]
		[Key]
		public int CarreraId { get; set; }
		[Required]
		[Column(TypeName = "varchar(255)")]
		public string Descripcion { get; set; }

		[IgnoreDataMember]
		[InverseProperty("Carrera")]
		public virtual ICollection<Interesados> Interesados { get; set; }
	}
}

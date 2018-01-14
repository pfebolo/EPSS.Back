using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EPSS.Models
{
	public enum EstadoDivisionId
	{
		Cursando,
		Terminado = 1,
		EnPreparacion = 2
	}
	

	public partial class EstadosDivision
	{
        public static readonly String[] Estados = { "Cursando", "Terminado", "En Preparación" };
		public EstadosDivision()
		{
			Divisiones = new HashSet<Divisiones>();
		}

		[Column("EstadoDivisionID")]
		[MaxLength(25)]
		[Key]
		public string EstadoDivisionId { get; set; }

		[IgnoreDataMember]
		[InverseProperty("EstadoDivision")]
		public virtual ICollection<Divisiones> Divisiones { get; set; }
	}
}

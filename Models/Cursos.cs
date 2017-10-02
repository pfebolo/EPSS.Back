using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace EPSS.Models
{
	[Table("Cursos")]
	public partial class Cursos
	{
		// int cursoId;
		public Cursos()
		{
			Divisiones = new HashSet<Divisiones>();
		}

		[Column("CarreraID")]
		public int CarreraId { get; set; }
		[Column("ModoID")]
		[MaxLength(25)]
		public string ModoId { get; set; }
		[Column("CursoID")]
		public int CursoId
		{
			get { return ((AnioInicio * 100 + MesInicio) * 10000) + (AnioLectivo * 100 + NmestreLectivo); }
			set
			{
				// if (value==0)

                // if (value == ((AnioInicio * 100 + MesInicio) * 10000) + (AnioLectivo * 100 + NmestreLectivo))
				// 	cursoId = value;
				// else
				// 	throw new Exception("Id Incorrecto");
			}
		}
		public int AnioInicio { get; set; }
		public int MesInicio { get; set; }
		public int MesFinal { get; set; }
		public int AnioLectivo { get; set; }
		[Column("NMestreLectivo")]
		public int NmestreLectivo { get; set; }
		[MaxLength(255)]
		public string Comentario { get; set; }

		[IgnoreDataMember]
		[InverseProperty("Cursos")]
		public virtual ICollection<Divisiones> Divisiones { get; set; }

		[ForeignKey("CarreraId")]
		[InverseProperty("Cursos")]
		public virtual Carreras Carrera { get; set; }


		[IgnoreDataMember]
		[ForeignKey("ModoId")]
		[InverseProperty("Cursos")]
		public virtual Modos Modo { get; set; }
	}
}

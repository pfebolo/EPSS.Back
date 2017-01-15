using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;



namespace API.Models
{
    public partial class EstadosCurso
    {
        public EstadosCurso()
        {
            Cursos = new HashSet<Cursos>();
        }

        [Column("EstadoCursoID")]
        [Key]
        public int EstadoCursoId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }

        [IgnoreDataMember]
        [InverseProperty("EstadoCurso")]
        public virtual ICollection<Cursos> Cursos { get; set; }
    }
}

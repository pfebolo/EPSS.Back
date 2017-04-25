using System;

namespace EPSS.DTOs
{
    public partial class Inscriptos
    {
        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Mail { get; set; }
        public string Mail2 { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string ComoConocio { get; set; }
        public string ModalidadId { get; set; }
        public string GradoInteres { get; set; }
        public System.DateTime? FechaInteresado { get; set; }
        public string Comentario { get; set; }
        public string Provincia { get; set; }
        public string SituacionInscripcion { get; set; }
        public string SituacionEspecial { get; set; }
        public string Domicilio { get; set; }
                
        public int? LegajoNro { get; set; }
    }
}

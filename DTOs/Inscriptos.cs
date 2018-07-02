using System;
using EPSS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPSS.DTOs
{
    public partial class Inscriptos
    {
        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; } //en el sistema anterior no se puede asegurar que todos los DNI son numericos,
        public string Mail { get; set; }
        public string Mail2 { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string ComoConocio { get; set; }
        //public string Modalidad { get; set; }
        public virtual Modalidades Modalidad { get; set; }
        public string GradoInteres { get; set; }
        public DateTime? FechaInteresado { get; set; }
        public string Comentario { get; set; }
        public string Provincia { get; set; }
        public string SituacionInscripcion { get; set; }
        public string SituacionEspecial { get; set; }
        public string Domicilio { get; set; }
        public DateTime? fechaInteresadoOriginal  { get; set; }
        public virtual Carreras Carrera { get; set; }
        public int? anioAcursar  { get; set; }
        public int? nmestreAcursar  { get; set; }
        public string turno  { get; set; }
        public DateTime? docTitulo  { get; set; }
        public DateTime? docDni  { get; set; }
        public DateTime? docAptoFisico  { get; set; }
        public DateTime? docFoto  { get; set; }
        public DateTime? docCompromiso  { get; set; }
        public int? LegajoNro { get; set; }
        public int? MedioDeContactoId { get; set; }
        public virtual Paises Nacionalidad { get; set; }
        


        [ForeignKey("MedioDeContactoId")]
        [InverseProperty("Alumnos")]
        public virtual MediosDeContacto MedioDeContacto { get; set; }
    }
}

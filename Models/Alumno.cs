using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCore.API.Models
{
		
		
		public class Alumno
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public string mail2 { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string como_conocio { get; set; }
        public Nullable<int> modalidad_id { get; set; }
        public string grado_interes { get; set; }
        public Nullable<System.DateTime> fecha_interesado { get; set; }
        public string comentario { get; set; }
        public string provincia { get; set; }
        public string situacion_inscripcion { get; set; }
        public string situacion_especial { get; set; }
        public string dni { get; set; }
        public string domicilio { get; set; }
    

    }

}
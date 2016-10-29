


using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WebCore.API.Models
{



public class Modalidad
{

    public Modalidad()
    {
        //this.Alumnos = new HashSet<Alumno>();
    }

    
    [Column("id"), Key]
    public int modalidad_id { get; set; }
    public string Nombre { get; set; }

    //[IgnoreDataMember]
    //public virtual ICollection<Alumno> Alumnos { get; set; }
    
}



}
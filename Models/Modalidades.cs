


using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCore.API.Models
{



public class Modalidad
{
    [Column("id")]
    public int ModalidadId { get; set; }
    public string Nombre { get; set; }
    
}



}
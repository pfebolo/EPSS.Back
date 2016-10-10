//SELECT TOP 1000 [id]
//      ,[nombre]
//  FROM [escuelapsdelsur].[dbo].[modalidades]


using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCore.API.Models
{

  public class EPSSContext : DbContext
    {
        public DbSet<Modalidad> Modalidades { get; set; }

    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Filename=../../../blog.db");
            //options.UseSqlServer(optionsBuilder.GetConnectionString("DefaultConnection"));
            //Console.WriteLine(Configuration.GetConnectionString("DefaultConnection") );
            optionsBuilder.UseSqlServer(@"Data Source=NB01\SQLEXPRESS;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=escuelapsdelsur;");
            Console.WriteLine("Configuracion");
        }
        


    }

public class Modalidad
{
    [Column("id")]
    public int ModalidadId { get; set; }
    public string Nombre { get; set; }
    
}



}
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
				public DbSet<Alumno> Alumnos { get; set; }
    
        public IConfigurationRoot Configuration { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            //optionsBuilder.UseSqlite("Filename=../../../blog.db");
            //options.UseSqlServer(optionsBuilder.GetConnectionString("DefaultConnection"));
            Console.WriteLine(Directory.GetCurrentDirectory() );
            Console.WriteLine(Configuration.GetConnectionString("DefaultConnection") );
            //optionsBuilder.UseSqlServer(@"Data Source=NB01\SQLEXPRESS;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=escuelapsdelsur;");
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            Console.WriteLine("Configuracion");
        }
        


    }



}
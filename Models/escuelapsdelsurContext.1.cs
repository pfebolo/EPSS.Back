using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace API.Models
{
    public partial class escuelapsdelsurContext : DbContext
    {
        public IConfigurationRoot Configuration { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            Console.WriteLine(@"*** CON CONFIG ***");
            Console.WriteLine("Configuracion:");
            Console.WriteLine(Directory.GetCurrentDirectory() );
            //optionsBuilder.UseSqlServer(@"Data Source=NB01\SQLEXPRESS;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=escuelapsdelsur;");
            //optionsBuilder.UseSqlServer(@"Data Source=NB01\SQLEXPRESS;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=escuelapsdelsur;");
            //string Configuracion = @"Data Source=192.168.1.41;Connect Timeout=15;Encrypt=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=escuelapsdelsur;User Id=sa;Password=sasasasa;";
            string Configuracion = Configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine(Configuracion);
            optionsBuilder.UseSqlServer(Configuracion);
        }
        

    }
}
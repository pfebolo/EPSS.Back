using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.Threading;
using EPSS.Rules;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using EPSS.Settings;


namespace EPSS
{
    public class Program
    {
        private static Timer tmr;
        
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                .AddEnvironmentVariables();

            settings.cargarConfiguracion(builder.Build());

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*:5000")
                .UseStartup<Startup>()
                .Build();


            ReglasDeInscripcion reglasDeInscripcion = new ReglasDeInscripcion();
            if (settings.procesosFrecuentes.CargarInscriptos)
                tmr = new Timer(reglasDeInscripcion.Cargar, null, settings.inscripcion.ejecucionInicialSegundos * 1000, settings.inscripcion.ejecucionFrecuenciaSegundos * 1000); 
            
            if (settings.procesosFrecuentes.MailsInscriptos)
                tmr = new Timer(reglasDeInscripcion.ProcesarMails, null, settings.inscripcion.ejecucionInicialSegundos * 1500, settings.inscripcion.ejecucionFrecuenciaSegundos * 1000); 

            host.Run();
        }
    }
}
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.Threading;
using EPSS.Rules;

namespace EPSS
{
    public class Program
    {
        private static Timer tmr;
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*:5000")
                .UseStartup<Startup>()
                .Build();


            ReglasDeInscripcion reglasDeInscripcion = new ReglasDeInscripcion();
            //TODO: Obtener los tiempos desde la configuración
            //tmr = new Timer(reglasDeInscripcion.Cargar, null, 60000, 180000); //60000=10 Minutos-180000=30minutos
            tmr = new Timer(reglasDeInscripcion.Cargar, null, 10000, Timeout.Infinite); 
            

            host.Run();
        }
    }
}
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
            
            tmr = new Timer(reglasDeInscripcion.Cargar, null, 180000, 180000); //180000=30minutos
            
            

            host.Run();
        }
    }
}
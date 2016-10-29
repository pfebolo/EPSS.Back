using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebCore.API.Models;
using API.Models;
using System;

using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace WebCore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Program>()
                .Build();



            host.Run();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("Program.Services");
            Console.WriteLine("Configurar CORS");
            services.AddCors(options => 
            {
                options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });
         
            services.AddMvc();
            
     

            //Borrar
            //services.AddSingleton<INoteRepository,NoteRepository>();
            //services.AddSingleton<IBlogRepository,BlogRepository>();
            //services.AddSingleton<IAlumnoRepository,AlumnoRepository>();

            //Oks
            //TODO: Incorporar por inyeccion de dependencias el contexto
            services.AddSingleton<IModalidadRepository,ModalidadRepository>();
            services.AddSingleton<IPaisesRepository,PaisesRepository>();
            services.AddSingleton<IProvinciasRepository,ProvinciasRepository>();
            services.AddSingleton<IPartidosRepository,PartidosRepository>();
            services.AddSingleton<ICodigosPostalesRepository,CodigosPostalesRepository>();
            services.AddSingleton<ILocalidadesRepository,LocalidadesRepository>();
            services.AddSingleton<IAlumnosRepository,AlumnosRepository>();
            services.AddSingleton<ILegajosRepository,LegajosRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseCors("AllowAll"); //usar antes de UseMvc ;)
            app.UseMvcWithDefaultRoute();
                        
            
        }

    }
}
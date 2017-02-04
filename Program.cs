﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using EPSS.Repositories;
using System;

using Microsoft.Extensions.Configuration;

namespace EPSS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*:5000")
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
            
     

            //TODO: Incorporar por inyeccion de dependencias el contexto
            services.AddSingleton<IModosRepository,ModosRepository>();
            services.AddSingleton<IModalidadesRepository,ModalidadesRepository>();
            services.AddSingleton<IPaisesRepository,PaisesRepository>();
            services.AddSingleton<IProvinciasRepository,ProvinciasRepository>();
            services.AddSingleton<IPartidosRepository,PartidosRepository>();
            services.AddSingleton<ICodigosPostalesRepository,CodigosPostalesRepository>();
            services.AddSingleton<ILocalidadesRepository,LocalidadesRepository>();
            services.AddSingleton<IAlumnosRepository,AlumnosRepository>();
            services.AddSingleton<ILegajosRepository,LegajosRepository>();
            services.AddSingleton<INivelesEstudiosRepository,NivelesEstudiosRepository>();
            services.AddSingleton<IEstudiosRepository,EstudiosRepository>();
            services.AddSingleton<IPromocionesRepository,PromocionesRepository>();
            services.AddSingleton<ICursosRepository,CursosRepository>();
            services.AddSingleton<ICoordinadoresRepository,CoordinadoresRepository>();
            services.AddSingleton<IGruposRepository,GruposRepository>();
            services.AddSingleton<ICoordinacionesRepository,CoordinacionesRepository>();
            services.AddSingleton<IBasicoRepository,BasicoRepository>();
            services.AddSingleton<IEstadosCursosRepository,EstadosCursosRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseCors("AllowAll"); //usar antes de UseMvc ;)
            app.UseMvcWithDefaultRoute();
                        
            
        }

    }
}
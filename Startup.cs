using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using EPSS.Repositories;
using Microsoft.Extensions.Logging;

namespace EPSS
{
    public class Startup
    {
        public ILogger _Logger;
        public ILoggerFactory _LoggerFactory;
        //public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory
              .AddConsole()
              .AddDebug();
            _LoggerFactory = loggerFactory;
            _Logger = loggerFactory.CreateLogger<Startup>();
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _Logger.LogInformation("ConfigureServices");
            _Logger.LogInformation("Configurar CORS");
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });

            _Logger.LogInformation("Agregando MVC");
            services.AddMvc();

            _Logger.LogInformation("Agregando Servicios");
            //TODO: Incorporar por inyeccion de dependencias el contexto
            services.AddSingleton<IModosRepository, ModosRepository>();
            services.AddSingleton<IModalidadesRepository, ModalidadesRepository>();
            services.AddSingleton<IPaisesRepository, PaisesRepository>();
            services.AddSingleton<IProvinciasRepository, ProvinciasRepository>();
            services.AddSingleton<IPartidosRepository, PartidosRepository>();
            services.AddSingleton<ICodigosPostalesRepository, CodigosPostalesRepository>();
            services.AddSingleton<ILocalidadesRepository, LocalidadesRepository>();
            services.AddSingleton<ILugaresRepository, LugaresRepository>();
            services.AddSingleton<IAlumnosRepository, AlumnosRepository>();
            services.AddSingleton<ILegajosRepository, LegajosRepository>();
            services.AddSingleton<INivelesEstudiosRepository, NivelesEstudiosRepository>();
            services.AddSingleton<IEstudiosRepository, EstudiosRepository>();
            services.AddSingleton<IPromocionesRepository, PromocionesRepository>();
            services.AddSingleton<ICursosRepository, CursosRepository>();
            services.AddSingleton<ICoordinadoresRepository, CoordinadoresRepository>();
            services.AddSingleton<IGruposRepository, GruposRepository>();
            services.AddSingleton<ICoordinacionesRepository, CoordinacionesRepository>();
            services.AddSingleton<IBasicoRepository, BasicoRepository>();
            services.AddSingleton<IEstadosCursosRepository, EstadosCursosRepository>();
            services.AddSingleton<IInscriptosRepository, InscriptosRepository>();
            services.AddSingleton<IInteresadosRepository, InteresadosRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            _Logger.LogInformation("UseCORS");
            app.UseCors("AllowAll"); //usar antes de UseMvc ;)
            _Logger.LogInformation("UseMvcWithDefaultRoute");
            app.UseMvcWithDefaultRoute();
            _Logger.LogInformation("Configurando logger general ");
        }

    }
}
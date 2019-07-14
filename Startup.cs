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

        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory
              .AddConsole()
              .AddDebug()
              .AddFile("Logs/myapp-{Date}.log");
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

            //Interface de Repositorio Genéricas
            services.AddSingleton<IRepository<Models.Carreras>, BaseRepositoryNew<Models.Carreras>>();
            services.AddSingleton<IRepository<Models.Turnos>, BaseRepositoryNew<Models.Turnos>>();
            services.AddSingleton<IRepository<Models.EstadosDivision>, BaseRepositoryNew<Models.EstadosDivision>>();
            services.AddSingleton<IRepository<Models.Dispositivos>, BaseRepositoryNew<Models.Dispositivos>>();
            services.AddSingleton<IRepository<Models.EstadosEstudiante>, BaseRepositoryNew<Models.EstadosEstudiante>>();
            services.AddSingleton<IRepository<Models.Coordinadores>, BaseRepositoryNew<Models.Coordinadores>>();
            services.AddSingleton<IRepository<Models.Informes>, BaseRepositoryNew<Models.Informes>>();


            //Interface de Repositorio Genérica extendidas
            services.AddSingleton<IGruposRepository, GruposRepository>();
            services.AddSingleton<IRepository<Models.Cursos>, CursosRepository>();
            services.AddSingleton<IRepository<Models.Divisiones>, DivisionesRepository>();
            services.AddSingleton<IRepository<Models.Coordinaciones>, CoordinacionesRepository>();
            services.AddSingleton<IRepository<Models.Lugares>, LugaresRepository>();
            services.AddSingleton<IRepository<Models.Interacciones>, InteraccionesRepository>();
            services.AddSingleton<IRepository<Models.InteraccionesInteresados>, InteraccionesInteresadosRepository>();
            

            //Interface de Repositorio específicas
            //TODO: Generalizarlas
            services.AddSingleton<IModosRepository, ModosRepository>();
            services.AddSingleton<IModalidadesRepository, ModalidadesRepository>();
            services.AddSingleton<IPaisesRepository, PaisesRepository>();
            services.AddSingleton<IProvinciasRepository, ProvinciasRepository>();
            services.AddSingleton<IPartidosRepository, PartidosRepository>();
            services.AddSingleton<ICodigosPostalesRepository, CodigosPostalesRepository>();
            services.AddSingleton<ILocalidadesRepository, LocalidadesRepository>();
            services.AddSingleton<IEventosRepository, EventosRepository>();
            services.AddSingleton<IAlumnosRepository, AlumnosRepository>();
            services.AddSingleton<ILegajosRepository, LegajosRepository>();
            services.AddSingleton<INivelesEstudiosRepository, NivelesEstudiosRepository>();
            services.AddSingleton<IEstudiosRepository, EstudiosRepository>();
            services.AddSingleton<IBasicoRepository, BasicoRepository>();
            services.AddSingleton<IInscriptosRepository, InscriptosRepository>();
            services.AddSingleton<IInteresadosRepository, InteresadosRepository>();
            services.AddSingleton<IInteresadosEventosRepository, InteresadosEventosRepository>();
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
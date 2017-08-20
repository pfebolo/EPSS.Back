using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace EPSS.Settings 
{
    public class settings 
    {
        public static IConfigurationRoot Configuration { get; set; }
        public static ConnectionStrings connectionStrings { get; set; } = new ConnectionStrings();
        public static Inscripcion inscripcion { get; set; } = new Inscripcion();
        public static SMTPSettings smtpSettings { get; set; } = new SMTPSettings();

        public static void cargarConfiguracion(IConfigurationRoot configuration)
        {
            Configuration = configuration;

            Configuration.GetSection("ConnectionStrings").Bind(connectionStrings);
            Configuration.GetSection("Inscripcion").Bind(inscripcion);
            Configuration.GetSection("SMTP").Bind(smtpSettings);
        }
	}
}
using System.IO;
using System.Text;
using System;
using System.Net;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using EPSS.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace EPSS.Rules
{
    public class ReglasDeInscripcion
    {
        private ILoggerFactory loggerFactory = new LoggerFactory().AddConsole().AddDebug();
        private ILogger _logger;
        private string[] inscripto = new String[46];
        private enum inscriptoCampos
        {
            ID = 0,
            Legajo = 1,
            Apellido = 2,
            Nombre = 3,
            Sexo = 4,
            FechaNacimiento = 5,
            LugarNacimiento = 6,
            DNI = 7,
            CUIT = 8,
            TelefonoFijo = 9,
            TelefonoCelular = 10,
            Email = 11,
            DireccionCalle = 12,
            DireccionNumero = 13,
            DireccionDepartamento = 14,
            DireccionOtros = 15,
            DireccionLocalidad = 16,
            DireccionCP = 17,
            DireccionProvincia = 18,
            DireccionPais = 19,
            TituloSecundario = 20,
            TituloSecundarioCarrera = 21,
            TituloSecundarioExpedidoPor = 22,
            EstudioTerciario = 23,
            EstudioTerciarioCompleto = 24,
            EstudioTerciarioCarrera = 25,
            EstudioTerciarioInstitucion = 26,
            EstudioUniversitario = 27,
            EstudioUniversitarioCompleto = 28,
            EstudioUniversitarioCarrera = 29,
            EstudioUniversitarioInstitucion = 30,
            Trabajo = 31,
            TrabajoLugar = 32,
            TrabajoCargo = 33,
            TrabajoAntiguedad = 34,
            TrabajoTelefono = 35,
            CursoAno = 36,
            CursoModalidad = 37,
            ConoceAAlguien = 38,
            Quien = 39,
            Aclaracion = 40,
            Historia = 41,
            Definicion = 42,
            Situacion = 43,
            Expectativas = 44,
            FechaDeInscripcion = 45
        }

        public ReglasDeInscripcion()
        {
            _logger = loggerFactory.CreateLogger(this.GetType().ToString());
            //TODO: Colocar, si es posible, el loggerFactory general
            //TODO: las clases que logean, sin importar su tarea, no deberain todas implementar una clase base de logueo
        }

        public void Cargar(object data)
        {
            //TODO: Obtener el path desde una configuración

            // get the page
            _logger.LogInformation("Actualizando inscripciones...");
            var request = WebRequest.CreateHttp("http://psicologiasocial.com.ar/inscripcion/ingresos/view.php");
            // start the asynchronous operation
            request.BeginGetResponse(new AsyncCallback(ProcesarHTML), request);
        }

        private void ProcesarHTML(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
            int indice;

            // End the operation
            using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult))
            {
                HtmlDocument doc = new HtmlDocument();
                Stream streamResponse = response.GetResponseStream();
                StreamReader reader = new StreamReader(streamResponse, Encoding.GetEncoding("iso-8859-1"));
                doc.Load(reader);

                foreach (HtmlNode filahtml in doc.DocumentNode.SelectNodes("/html[1]/body[1]/table[1]/tr[position()>1]"))
                {
                    indice = 0;
                    foreach (HtmlNode columnahtml in filahtml.SelectNodes("td"))
                    {
                        inscripto[indice] = columnahtml.InnerText;
                        indice += 1;
                    }
                    ActualizarInscripto(inscripto);
                    //_logger.LogInformation("Actualización de Inscripciones interrumpidas ;(");
                    //break;
                }
                _logger.LogInformation("Inscripciones Actualizadas :)");

            }
        }

        private void ActualizarInscripto(string[] inscripto)
        {
            try
            {
                using (var db = new escuelapsdelsurContext())
                {
                    int NroDni = 0;

                    Int32.TryParse(inscripto[(int)inscriptoCampos.DNI].Replace(".", ""), out NroDni);
                    // StringBuilder    registro=new StringBuilder(""); 
                    // for (int campo = 0; campo<inscripto.Length ; campo++)
                    // {
                    //     registro.Append(inscripto[campo]);
                    //     registro.Append(",");
                    // }
                    // Console.WriteLine(registro.ToString());
                    Console.WriteLine(NroDni.ToString());
                    if (db.Alumnos.Count(x => x.Dni.Trim() == NroDni.ToString()) == 1)
                    {
                        var alumno = db.Alumnos.Single(x => x.Dni.Trim() == NroDni.ToString());
                        alumno.Comentario = inscripto[(int)inscriptoCampos.Aclaracion];
                        alumno.Cuestionario = DateTime.Now;
                        //db.Update(item);
                        db.SaveChanges();
                        Console.WriteLine(NroDni.ToString() + "--> encontrado");

                    }


                    //foreach (var Alumno in db.Alumnos.Include(a => a.Modalidad))



                    //_logger.LogInformation("Inscripto Actualizado");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
        }

        // private static void ProcesarHTML(IAsyncResult asynchronousResult)
        // {
        //     using (FileStream archivo = File.Open("/home/pablo/Desarrollo/EPSS/ingresos.xls", FileMode.Open))
        //     {
        //         HtmlDocument doc = new HtmlDocument();
        //         StreamReader reader = new StreamReader(archivo, Encoding.GetEncoding("iso-8859-1"));
        //         doc.Load(reader);

        //         foreach (HtmlNode filahtml in doc.DocumentNode.SelectNodes("/html[1]/body[1]/table[1]/tr[position()>1]"))
        //         {
        //             foreach (HtmlNode columnahtml in filahtml.SelectNodes("td"))
        //             {
        //                 Console.Write(columnahtml.InnerText + ",");
        //             }
        //             Console.WriteLine();
        //         }

        //     }
        // }

    }
}

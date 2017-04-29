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
        private int _inscriptosEncontradosOK = 0;
        private int _inscriptosEncontradosNoOK = 0;
        private int _inscriptosNoEncontrados = 0;

        private string[] inscripto = new String[45];
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
            EstudioSecundario = 20,
            EstudioSecundarioCarrera = 21,
            EstudioSecundarioExpedidoPor = 22,
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
            Aclaracion = 39,
            Historia = 40,
            Definicion = 41,
            Situacion = 42,
            Expectativas = 43,
            FechaDeInscripcion = 44
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
            _logger.LogInformation("Actualizando legajos...");
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
                _inscriptosEncontradosOK = 0;
                _inscriptosEncontradosNoOK = 0;
                _inscriptosNoEncontrados = 0;
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
                _logger.LogInformation("Legajos Actualizados :)");
                _logger.LogInformation("DNIs encontrados OK:" + _inscriptosEncontradosOK.ToString());
                _logger.LogInformation("DNIs con error:" + _inscriptosEncontradosNoOK.ToString());
                _logger.LogInformation("DNIs NO encontrados, o procesados previamente:" + _inscriptosNoEncontrados.ToString());

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
                    _logger.LogInformation("Procesando DNI:" + NroDni.ToString());
                    if (db.Legajos.Count(x => (x.Dni == NroDni) && (x.Cuestionario == null)) == 1)
                    {
                        try
                        {
                            StringBuilder registro = new StringBuilder("");
                            for (int campo = 0; campo < inscripto.Length; campo++)
                            {
                                registro.Append(inscripto[campo]);
                                registro.Append(",");
                            }
                            _logger.LogInformation("Fila: " + registro.ToString());

                            Legajos legajo = db.Legajos.Single(x => x.Dni == NroDni);
                            legajo.Sexo = inscripto[(int)inscriptoCampos.Sexo].Trim();
                            legajo.FechaNacimiento = DateTime.Parse(inscripto[(int)inscriptoCampos.FechaNacimiento]);
                            legajo.LugarNacimiento = inscripto[(int)inscriptoCampos.LugarNacimiento].Trim();
                            legajo.DireccionCalle = inscripto[(int)inscriptoCampos.DireccionCalle].Trim();
                            legajo.DireccionNro = inscripto[(int)inscriptoCampos.DireccionNumero].Trim();
                            legajo.DireccionCoordenadaInterna = inscripto[(int)inscriptoCampos.DireccionDepartamento].Trim() + ", " + inscripto[(int)inscriptoCampos.DireccionOtros].Trim();
                            legajo.LocalidadBase = inscripto[(int)inscriptoCampos.DireccionLocalidad].Trim();
                            legajo.SecundarioCompletoOley25 = false;
                            legajo.Comentarios = inscripto[(int)inscriptoCampos.Aclaracion];
                            int CPBase = 0;
                            int.TryParse(inscripto[(int)inscriptoCampos.DireccionCP].Trim(), out CPBase);
                            legajo.CodigoPostalBase = CPBase;
                            legajo.FechaIngreso = DateTime.Parse(inscripto[(int)inscriptoCampos.FechaDeInscripcion]);
                            legajo.ModalidadBase = inscripto[(int)inscriptoCampos.CursoModalidad];
                            legajo.Cuestionario = DateTime.Parse(inscripto[(int)inscriptoCampos.FechaDeInscripcion]);
                            //Estudios
                            int Estudio_ID=0;
                            //Secundario
                            Estudios estudio = new Estudios();
                            estudio.AlumnoId = legajo.AlumnoId;
                            Estudio_ID +=1;
                            estudio.EstudioId = Estudio_ID;
                            estudio.NivelEstudioId = "Secundario";
                            estudio.Titulo = inscripto[(int)inscriptoCampos.EstudioSecundarioCarrera].Trim();
                            estudio.Institucion = inscripto[(int)inscriptoCampos.EstudioSecundarioExpedidoPor].Trim();
                            estudio.Terminado = (inscripto[(int)inscriptoCampos.EstudioSecundario].Trim().ToUpper() == "SI");
                            db.Estudios.Add(estudio);
                            if ((inscripto[(int)inscriptoCampos.EstudioTerciario].Trim() != "") ||
                                (inscripto[(int)inscriptoCampos.EstudioTerciarioCompleto].Trim() != "") ||
                                (inscripto[(int)inscriptoCampos.EstudioTerciarioCarrera].Trim() != "") ||
                                (inscripto[(int)inscriptoCampos.EstudioTerciarioInstitucion].Trim() != ""))
                            {
                                estudio = new Estudios();
                                estudio.AlumnoId = legajo.AlumnoId;
                                Estudio_ID +=1;
                                estudio.EstudioId = Estudio_ID;
                                estudio.NivelEstudioId = "Terciario";
                                estudio.Titulo = inscripto[(int)inscriptoCampos.EstudioTerciarioCarrera].Trim();
                                estudio.Institucion = inscripto[(int)inscriptoCampos.EstudioTerciarioCarrera].Trim();
                                estudio.Terminado = (inscripto[(int)inscriptoCampos.EstudioTerciarioCompleto].Trim().ToUpper() == "SI");
                            }
                            if ((inscripto[(int)inscriptoCampos.EstudioUniversitario].Trim() != "") ||
                                (inscripto[(int)inscriptoCampos.EstudioUniversitarioCompleto].Trim() != "") ||
                                (inscripto[(int)inscriptoCampos.EstudioUniversitarioCarrera].Trim() != "") ||
                                (inscripto[(int)inscriptoCampos.EstudioUniversitarioInstitucion].Trim() != ""))
                            {
                                estudio = new Estudios();
                                estudio.AlumnoId = legajo.AlumnoId;
                                Estudio_ID +=1;
                                estudio.EstudioId = Estudio_ID;
                                estudio.NivelEstudioId = "Universitario";
                                estudio.Titulo = inscripto[(int)inscriptoCampos.EstudioUniversitarioCarrera].Trim();
                                estudio.Institucion = inscripto[(int)inscriptoCampos.EstudioUniversitarioCarrera].Trim();
                                estudio.Terminado = (inscripto[(int)inscriptoCampos.EstudioUniversitarioCompleto].Trim().ToUpper() == "SI");
                            }
                            db.SaveChanges();
                            _logger.LogInformation("Legajo con DNI" + NroDni.ToString() + " encontrado y actualizado satisfactoriamente.");
                            _inscriptosEncontradosOK += 1;
                        }
                        catch (System.Exception ex)
                        {
                            _logger.LogInformation(ex.Message);
                            _inscriptosEncontradosNoOK += 1;
                        }
                    }
                    else
                    {
                        _logger.LogDebug(NroDni.ToString() + " No encontrado o previamente procesado.");
                        _inscriptosNoEncontrados += 1;
                    }
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


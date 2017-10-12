using System.IO;
using System.Text;
using System;
using System.Net;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using EPSS.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EPSS.Controllers;
using EPSS;
using EPSS.Settings;
using MimeKit;
using MailKit.Security;
using EPSS.Mail;

namespace EPSS.Rules
{
	public class ReglasDeInscripcion
	{
		private ILoggerFactory loggerFactory = new LoggerFactory().AddConsole().AddDebug().AddFile("Logs/Inscripcion-{Date}.log");
		private ILogger _logger;
		private int _inscriptosEncontradosOK = 0;
		private int _inscriptosEncontradosNoOK = 0;
		private int _inscriptosNoEncontrados = 0;
		private const string REINTENTO = "Reintento";
		private static bool MailInscripcionEnProceso = false;


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
			// get the page
			_logger.LogInformation("Actualizando legajos...");
			var request = WebRequest.CreateHttp(settings.inscripcion.url);
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
				using (var db = new escuelapsdelsurContext())
				{
					foreach (HtmlNode filahtml in doc.DocumentNode.SelectNodes("/html[1]/body[1]/table[1]/tr[position()>1]"))
					{
						indice = 0;
						foreach (HtmlNode columnahtml in filahtml.SelectNodes("td"))
						{
							inscripto[indice] = columnahtml.InnerText;
							indice += 1;
						}
						ActualizarInscripto(inscripto, db);
					}
				}
				_logger.LogInformation("Legajos Actualizados :)");
				_logger.LogInformation("DNIs encontrados OK:" + _inscriptosEncontradosOK.ToString());
				_logger.LogInformation("DNIs con error:" + _inscriptosEncontradosNoOK.ToString());
				_logger.LogInformation("DNIs NO encontrados, o procesados previamente:" + _inscriptosNoEncontrados.ToString());
				_logger.LogInformation("----------------------------------------------------------------------");
				reader.Dispose();
				streamResponse.Dispose();
				doc = null;
			}
			request = null;
		}

		private void ActualizarInscripto(string[] inscripto, escuelapsdelsurContext db)
		{
			try
			{
				int NroDni = 0;
				DateTime dtProvisorio;
				Legajos legajo = null;

				Int32.TryParse(inscripto[(int)inscriptoCampos.DNI].Replace(".", ""), out NroDni);
				_logger.LogInformation("Procesando DNI:" + NroDni.ToString());
				if (db.Legajos.Count(x => (x.Dni == NroDni) && (x.Cuestionario == null)) == 1)
				{
					using (var dbContextTransaction = db.Database.BeginTransaction())
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

							legajo = db.Legajos.Single(x => x.Dni == NroDni);
							legajo.Sexo = inscripto[(int)inscriptoCampos.Sexo].Trim();
							if (DateTime.TryParse(inscripto[(int)inscriptoCampos.FechaNacimiento], out dtProvisorio))
								legajo.FechaNacimiento = dtProvisorio;
							else
								legajo.FechaNacimiento = new DateTime(1900, 1, 1); //MinValue form smallDateTime (type of DB Column)
							legajo.LugarNacimiento = inscripto[(int)inscriptoCampos.LugarNacimiento].Trim();
							legajo.DireccionCalle = inscripto[(int)inscriptoCampos.DireccionCalle].Trim();
							legajo.DireccionNro = inscripto[(int)inscriptoCampos.DireccionNumero].Trim();
							legajo.DireccionCoordenadaInterna = inscripto[(int)inscriptoCampos.DireccionDepartamento].Trim() + ", " + inscripto[(int)inscriptoCampos.DireccionOtros].Trim();
							legajo.LocalidadBase = inscripto[(int)inscriptoCampos.DireccionLocalidad].Trim();
							legajo.SecundarioCompletoOley25 = false;
							legajo.Comentarios = inscripto[(int)inscriptoCampos.Aclaracion].Trim();
							int CPBase = 0;
							int.TryParse(inscripto[(int)inscriptoCampos.DireccionCP].Trim(), out CPBase);
							legajo.CodigoPostalBase = CPBase;
							legajo.FechaIngreso = DateTime.Parse(inscripto[(int)inscriptoCampos.FechaDeInscripcion]);
							legajo.ModalidadBase = inscripto[(int)inscriptoCampos.CursoModalidad];
							legajo.Cuestionario = DateTime.Parse(inscripto[(int)inscriptoCampos.FechaDeInscripcion]);
							legajo.Historia = inscripto[(int)inscriptoCampos.Historia].Trim();
							legajo.Definicion = inscripto[(int)inscriptoCampos.Definicion].Trim();
							legajo.Situacion = inscripto[(int)inscriptoCampos.Situacion].Trim();
							legajo.Expectativas = inscripto[(int)inscriptoCampos.Expectativas].Trim();

							//Estudios
							int Estudio_ID = 500;
							//Secundario
							Estudios estudio;
							Estudio_ID += 1;
							estudio = db.Estudios.SingleOrDefault(x => x.AlumnoId == legajo.AlumnoId && x.EstudioId == Estudio_ID) ?? new Estudios(legajo.AlumnoId, Estudio_ID);
							estudio.NivelEstudioId = "Secundario";
							estudio.Titulo = inscripto[(int)inscriptoCampos.EstudioSecundarioCarrera].Trim();
							estudio.Institucion = inscripto[(int)inscriptoCampos.EstudioSecundarioExpedidoPor].Trim();
							estudio.Terminado = (inscripto[(int)inscriptoCampos.EstudioSecundario].Trim().ToUpper() == "SI");
							if (!db.Estudios.Contains(estudio))
							{
								db.Estudios.Add(estudio);
							}
							if ((inscripto[(int)inscriptoCampos.EstudioTerciarioCarrera].Trim() != "") ||
									(inscripto[(int)inscriptoCampos.EstudioTerciarioInstitucion].Trim() != ""))
							{
								Estudio_ID += 1;
								estudio = db.Estudios.SingleOrDefault(x => x.AlumnoId == legajo.AlumnoId && x.EstudioId == Estudio_ID) ?? new Estudios(legajo.AlumnoId, Estudio_ID);
								estudio.NivelEstudioId = "Terciario";
								estudio.Titulo = inscripto[(int)inscriptoCampos.EstudioTerciarioCarrera].Trim();
								estudio.Institucion = inscripto[(int)inscriptoCampos.EstudioTerciarioCarrera].Trim();
								estudio.Terminado = (inscripto[(int)inscriptoCampos.EstudioTerciarioCompleto].Trim().ToUpper() == "SI");
								if (!db.Estudios.Contains(estudio))
								{
									db.Estudios.Add(estudio);
								}
							}
							if ((inscripto[(int)inscriptoCampos.EstudioUniversitarioCarrera].Trim() != "") ||
									(inscripto[(int)inscriptoCampos.EstudioUniversitarioInstitucion].Trim() != ""))
							{
								Estudio_ID += 1;
								estudio = db.Estudios.SingleOrDefault(x => x.AlumnoId == legajo.AlumnoId && x.EstudioId == Estudio_ID) ?? new Estudios(legajo.AlumnoId, Estudio_ID);
								estudio.NivelEstudioId = "Universitario";
								estudio.Titulo = inscripto[(int)inscriptoCampos.EstudioUniversitarioCarrera].Trim();
								estudio.Institucion = inscripto[(int)inscriptoCampos.EstudioUniversitarioCarrera].Trim();
								estudio.Terminado = (inscripto[(int)inscriptoCampos.EstudioUniversitarioCompleto].Trim().ToUpper() == "SI");
								if (!db.Estudios.Contains(estudio))
								{
									db.Estudios.Add(estudio);
								}
							}

							//Trabajos
							Trabajos trabajo;
							int Trabajo_ID = 500;
							if ((inscripto[(int)inscriptoCampos.TrabajoAntiguedad].Trim() != "") ||
									(inscripto[(int)inscriptoCampos.TrabajoCargo].Trim() != "") ||
									(inscripto[(int)inscriptoCampos.TrabajoLugar].Trim() != "") ||
									(inscripto[(int)inscriptoCampos.TrabajoTelefono].Trim() != ""))
							{
								Trabajo_ID += 1;
								trabajo = db.Trabajos.SingleOrDefault(x => x.AlumnoId == legajo.AlumnoId && x.TrabajoId == Trabajo_ID) ?? new Trabajos(legajo.AlumnoId, Trabajo_ID);
								trabajo.Antiguedad = inscripto[(int)inscriptoCampos.TrabajoAntiguedad].Trim();
								trabajo.Cargo = inscripto[(int)inscriptoCampos.TrabajoCargo].Trim();
								trabajo.RazonSocial = inscripto[(int)inscriptoCampos.TrabajoLugar].Trim();
								trabajo.Telefono = inscripto[(int)inscriptoCampos.TrabajoTelefono].Trim();
								if (!db.Trabajos.Contains(trabajo))
								{
									db.Trabajos.Add(trabajo);
								}
							}
							db.SaveChanges();
							dbContextTransaction.Commit();
							_logger.LogInformation("Legajo con DNI" + NroDni.ToString() + " encontrado y actualizado satisfactoriamente.");
							_inscriptosEncontradosOK += 1;
						}

						catch (System.Exception ex)
						{
							dbContextTransaction.Rollback();
							//Rollback del Contexto
							DbContextHelper dbHelper = new DbContextHelper(db);
							dbHelper.tableRollback<Estudios>(legajo.Estudios);
							dbHelper.tableRollback<Trabajos>(legajo.Trabajos);
							dbHelper.entryRollback(legajo);
							_logger.LogError(new EventId(), ex, null);
							_inscriptosEncontradosNoOK += 1;
						}
					}
				}
				else
				{
					_logger.LogInformation(NroDni.ToString() + " No encontrado o previamente procesado.");
					_inscriptosNoEncontrados += 1;
				}

			}
			catch (System.Exception ex)
			{
				_logger.LogError(new EventId(), ex, null);
			}
		}

		public void EnviarEmail(Models.Alumnos Inscripto, MailboxAddress contactFrom, MailboxAddress contactBCC, MailEasy mail)
		{
			MailboxAddress contactTo = null;
			string emailaddress = Inscripto.Mail.Replace("%40", "@");
			if (!settings.inscripcion.ModoTest)
				contactTo = new MailboxAddress(Inscripto.Apellido + ", " + Inscripto.Nombre, emailaddress);
			else
				contactTo = new MailboxAddress("Test: " + Inscripto.Apellido + ", " + Inscripto.Nombre, settings.inscripcion.ReceptorTestEmailDireccion);
			string mensajeAEnviar = settings.inscripcion.MensajeBienvenida;
			mensajeAEnviar = mensajeAEnviar.Replace("{{nombreInscripto}}", Inscripto.Nombre);
			BodyHtml body = new BodyHtml("Link de Inscripción", mensajeAEnviar);
			mail.send(contactFrom, contactTo, contactBCC, body);
			_logger.LogInformation("E-Mails de Inscripción enviado a: " + Inscripto.Apellido + ", " + Inscripto.Nombre + " -> " + emailaddress);
		}

		private string DeterminarProximoReintento(String EstadoOriginal)
		{
			int reintento = 1;
			int reintentosMax = settings.inscripcion.Reintentos;
			string ReintentoDeterminado = "Error"; //Si se alcanzó el máximo de Reintentos, se coloca en error-
			if (reintentosMax >= reintento)
				if (EstadoOriginal != "Enviar")
				{
					int.TryParse(EstadoOriginal.Substring(REINTENTO.Length + 1), out reintento);
					reintento++;
					if (reintento <= reintentosMax)
						ReintentoDeterminado = REINTENTO + "-" + reintento.ToString();
				}
				else
					ReintentoDeterminado = REINTENTO + "-" + reintento.ToString();
			return ReintentoDeterminado;
		}

		public void ProcesarMails(object data)
		{
			if (!MailInscripcionEnProceso)
			{
				MailInscripcionEnProceso = true;
				try
				{
					MailEasy mail = new MailEasy(settings.smtpSettings);
					MailboxAddress From = new MailboxAddress(settings.inscripcion.EmisorEmailNombre, settings.inscripcion.EmisorEmailDireccion);
					MailboxAddress CCO = null;
					if (!string.IsNullOrEmpty(settings.inscripcion.CCOEmailDireccion))
						CCO = new MailboxAddress(settings.inscripcion.CCOEmailNombre, settings.inscripcion.CCOEmailDireccion);
					mail.Conectar(); //Posible error de conexión a servidor de mail 
					int EmailsEnviados = 0;
					int EmailsConError = 0;

					using (var db = new escuelapsdelsurContext())
					{
						var alumnos = db.Alumnos.Where(x => x.Mail2 == "Enviar" || x.Mail2.StartsWith(REINTENTO)).ToList();
						foreach (Alumnos alumno in alumnos)
						{
							try
							{
								/* --Contol de re-envio infinito de e-mails--
								Al grabar/cambiar el estado de envío antes del envío del e-mail, se controla 
								el eventual re-envio infinito de mails, si no se grabará el estado, 
								en caso de un error en la grabación al estado 'Enviado' 
								(posterior al envío exitoso del e-mail), este quedaría en 'Enviar' y 
								volvería a enviar el e-mail (en la próximo ciclo) incorrectamente.
								Si se genera un error al grabar el estado, no enviará el email por estar en bloque try.
								En el peor de los casos quedaría en un loop hasta corregir el problema de
								grabación de estado, pero no de envío de e-mails.
								*/
								alumno.Mail2 = DeterminarProximoReintento(alumno.Mail2);
								db.SaveChanges();

								//Se intenta enviar el Mail
								EnviarEmail(alumno, From, CCO, mail);
								alumno.Mail2 = "Enviado"; //Estado que toma al enviar exitosamente el envio.
								db.SaveChanges(); //Graba estado de envío exitoso.
								EmailsEnviados++;
							}
							catch (System.Exception ex)
							{
								EmailsConError++;
								DbContextHelper dbHelper = new DbContextHelper(db);
								dbHelper.entryRollback(alumno);
								_logger.LogError(new EventId(), ex, null);
							}
						}
						if (EmailsEnviados != 0 || EmailsConError != 0)
						{
							_logger.LogInformation("E-Mails de Inscripción de completado de cuestionario enviados: " + EmailsEnviados.ToString());
							_logger.LogInformation("E-Mails de Inscripción de completado de cuestionario con error: " + EmailsConError.ToString());
							_logger.LogInformation("----------------------------------------------------------------------");
						}
						else
							_logger.LogInformation("E-Mails de Inscripción de completado de cuestionario sin inscriptos a procesar");
					}
					mail.DesConectar();
				}
				catch (System.Exception ex)
				{
					_logger.LogError(new EventId(), ex, null); //Posible error de conexión a servidor de mail
				}
				MailInscripcionEnProceso = false;
			}
			else
			{
				_logger.LogInformation("E-Mails de Inscripción de completado de cuestionario en proceso, se reintentará a próximo ciclo.");
			}

		}
	}
}


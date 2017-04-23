using System.IO;
using System.Text;
using System;
using System.Net;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;

namespace EPSS
{
    public  class ReglasDeInscripcion
    {
        private ILoggerFactory loggerFactory = new LoggerFactory().AddConsole().AddDebug();
        private ILogger _logger;

        public ReglasDeInscripcion()
        {
            _logger = loggerFactory.CreateLogger(this.GetType().ToString());
            //TODO: Colocar, si es posible, el loggerFactory general
            //TODO: las clases que logean, sin importar su tarea, no deberain todas implementar una clase base de logueo
        }

        public  void Cargar(object data)
        {
            //TODO: Obtener el path desde una configuración

            // get the page
            _logger.LogInformation("Actualizando inscripciones...");
            var request = WebRequest.CreateHttp("http://psicologiasocial.com.ar/inscripcion/ingresos/view.php");
            // start the asynchronous operation
            request.BeginGetResponse(new AsyncCallback(ProcesarHTML), request);
        }

        private  void ProcesarHTML(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;

            // End the operation
            using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult))
            {
                HtmlDocument doc = new HtmlDocument();
                Stream streamResponse = response.GetResponseStream();
                StreamReader reader = new StreamReader(streamResponse, Encoding.GetEncoding("iso-8859-1"));
                doc.Load(reader);

                foreach (HtmlNode filahtml in doc.DocumentNode.SelectNodes("/html[1]/body[1]/table[1]/tr[position()>1]"))
                {
                    foreach (HtmlNode columnahtml in filahtml.SelectNodes("td"))
                    {
                        Console.Write(columnahtml.InnerText + ",");
                    }
                    _logger.LogInformation("Inscripciones Actualizadas.");
                    break;

                }

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

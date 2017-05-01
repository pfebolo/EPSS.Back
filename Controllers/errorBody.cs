using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace EPSS.Controllers
{
    public class errorBody
    {
        public class error {
            public string codigo { get; }  = string.Empty;
            public string mensaje { get; } = string.Empty;

            public error (string codigo, string mensaje) {
                this.codigo = codigo;
                this.mensaje = mensaje;
            }
        }
        public Stack<error> mensajes { get; set; } = new Stack<error>();

        public errorBody(System.Exception ex)
        {
            System.Exception iex;
            iex = ex;
            do
            {
                mensajes.Push(new error(iex.GetType().ToString() + " (0x" + iex.HResult.ToString("X") + ")" ,iex.Message));
                iex = iex.InnerException;
            } while (iex != null);
        }

        public errorBody(string mensajeDeError)
        {
            mensajes.Push(new error(typeof(System.Exception).ToString() ,mensajeDeError));
        }

        public override string ToString() {
            string str = JsonConvert.SerializeObject(this);
            return str;
        }

    }
}
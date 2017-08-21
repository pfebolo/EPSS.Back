namespace EPSS.Settings
{
    public class Inscripcion
    {
        public int ejecucionInicialSegundos { get; set; }
        public int ejecucionFrecuenciaSegundos { get; set; }
        public string url { get; set; }
        public string  EmisorEmailNombre { get; set; }
        public string  EmisorEmailDireccion { get; set; }
        public int  Reintentos { get; set; }
        public string MensajeBienvenida { get; set; }
        public bool ModoTest  { get; set; }
        public string ReceptorTestEmailDireccion { get; set; }


    }
}
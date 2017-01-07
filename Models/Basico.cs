using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebCore.API.Models
{
    public class Basico
    {

        public Basico()
        {
            Basico_id=1;
            Nombre="Iniciado";
        }


        [Column("id"), Key]
        public int Basico_id { get; set; }
        public string Nombre { get; set; }
    }
}
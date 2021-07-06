using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Armamento
    {
        [Key]
        public int IdInventario { get; set; }
        public int IdPersonagem { get; set; }
        public int IdArma { get; set; }
    }
}
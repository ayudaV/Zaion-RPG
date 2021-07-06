using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Inventario
    {
        [Key]
        public int IdInventario { get; set; }
        public int IdPersonagem { get; set; }
        public int IdItem { get; set; }
    }
}
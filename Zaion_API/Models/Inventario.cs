using System.ComponentModel.DataAnnotations;

namespace Zaion_API.Models
{
    public class Inventario
    {
        [Key]
        public int IdInventario { get; set; }
        public int IdPersonagem { get; set; }
        public int IdItem { get; set; }
    }
}
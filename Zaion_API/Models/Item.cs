using System.ComponentModel.DataAnnotations;

namespace Zaion_API.Models
{
    public class Item
    {
        [Key]
        public int IdItem { get; set; }
        public string Nome { get; set; }
        public double Peso { get; set; }
        public string Descricao { get; set; }
    }
}
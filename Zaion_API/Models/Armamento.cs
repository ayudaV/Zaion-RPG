using System.ComponentModel.DataAnnotations;

namespace Zaion_API.Models
{
    public class Armamento
    {
        [Key]
        public int IdArmamento { get; set; }
        public int IdPersonagem { get; set; }
        public int IdArma { get; set; }
    }
}
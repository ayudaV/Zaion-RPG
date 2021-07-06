using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Arma
    {
        [Key]
        public int IdArma { get; set; }
        public string Nome { get; set; }
        public string Dano { get; set; }
        public string Tipo { get; set; }
        public double Peso { get; set; }
        public int Pente_Raio { get; set; }
        public string Descricao { get; set; }
    }
}
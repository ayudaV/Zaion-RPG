using System.ComponentModel.DataAnnotations;

namespace Zaion_API.Models
{
    public class Jogador
    {
        [Key]
        public int IdJogador { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string NomeJogador { get; set; }
        public string UrlImagem { get; set; }
        public string Descricao { get; set; }
        public string Role { get; set; }

    }
}
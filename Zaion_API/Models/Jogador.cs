using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Jogador
    {
        [Key]
        public int IdJogador { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string NomeJogador { get; set; }

    }
}
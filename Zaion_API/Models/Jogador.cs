using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
namespace Zaion_API.Models
{
    public class Jogador
    {
        [Key]
        public int IdJogador { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string NomeJogador { get; set; }
        public string NomeImagem { get; set; }
        public string Descricao { get; set; }
        public string Role { get; set; }

        [NotMapped]
        public IFormFile ArquivoImagem { get; set; }

    }
}
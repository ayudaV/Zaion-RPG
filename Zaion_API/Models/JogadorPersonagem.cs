using System.ComponentModel.DataAnnotations;
using System;
namespace api.Models
{
    public class JogadorPersonagem
    {
        public virtual Jogador Jogador { get; set; }
        public virtual Personagem Personagem { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System;
namespace Zaion_API.Models
{
    public class PersonagemJogador
    {
        public virtual Personagem Personagem { get; set; }
        public virtual Jogador Jogador { get; set; }
    }
}
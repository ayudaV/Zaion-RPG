using System.ComponentModel.DataAnnotations;
using System;
namespace api.Models
{
    public class PersonagemArmamento
    {
        public virtual Personagem Personagem { get; set; }
        public virtual Armamento Armamento { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System;
namespace Zaion_API.Models
{
    public class PersonagemArmamento
    {
        public virtual Personagem Personagem { get; set; }
        public virtual Armamento Armamento { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System;
namespace Zaion_API.Models
{
    public class ArmamentoPersonagem
    {
        public virtual Armamento Armamento { get; set; }
        public virtual Personagem Personagem { get; set; }
    }
}
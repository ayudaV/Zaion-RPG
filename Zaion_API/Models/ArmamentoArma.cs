using System.ComponentModel.DataAnnotations;
using System;
namespace Zaion_API.Models
{
    public class ArmamentoArma
    {
        public virtual Armamento Armamento { get; set; }
        public virtual Arma Arma { get; set; }
    }
}
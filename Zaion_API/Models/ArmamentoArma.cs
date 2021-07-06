using System.ComponentModel.DataAnnotations;
using System;
namespace api.Models
{
    public class ArmamentoArma
    {
        public virtual Armamento Armamento { get; set; }
        public virtual Arma Arma { get; set; }
    }
}
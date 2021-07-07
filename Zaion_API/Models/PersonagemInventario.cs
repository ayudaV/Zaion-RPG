using System.ComponentModel.DataAnnotations;
using System;
namespace Zaion_API.Models
{
    public class PersonagemInventario
    {
        public virtual Personagem Personagem { get; set; }
        public virtual Inventario Inventario { get; set; }
    }
}
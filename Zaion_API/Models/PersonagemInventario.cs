using System.ComponentModel.DataAnnotations;
using System;
namespace api.Models
{
    public class PersonagemInventario
    {
        public virtual Personagem Personagem { get; set; }
        public virtual Inventario Inventario { get; set; }
    }
}
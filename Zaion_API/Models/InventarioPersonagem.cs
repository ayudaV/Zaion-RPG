using System.ComponentModel.DataAnnotations;
using System;
namespace Zaion_API.Models
{
    public class InventarioPersonagem
    {
        public virtual Inventario Inventario { get; set; }
        public virtual Personagem Personagem { get; set; }
    }
}
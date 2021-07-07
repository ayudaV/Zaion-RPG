using System.ComponentModel.DataAnnotations;
using System;
namespace Zaion_API.Models
{
    public class InventarioItem
    {
        public virtual Inventario Inventario { get; set; }
        public virtual Item Item { get; set; }
    }
}
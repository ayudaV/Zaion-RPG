using System.ComponentModel.DataAnnotations;
using System;
namespace api.Models
{
    public class InventarioItem
    {
        public virtual Inventario Inventario { get; set; }
        public virtual Item Item { get; set; }
    }
}
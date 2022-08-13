using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DolibarrIntegration.Models
{
    
    public class Product
    {
        [Display(Name = "Referencia")]
        public string @ref { get; set; }

        [Display(Name = "Producto")]
        public string label { get; set; }

        [Display(Name = "Descripción")]
        public string description { get; set; }

        [Display(Name = "Precio")]
        public decimal price { get; set; }
    }
}

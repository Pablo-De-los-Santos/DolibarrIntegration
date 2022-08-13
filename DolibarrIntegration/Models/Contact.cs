using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DolibarrIntegration.Models
{
    public class Contact
    {
        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Teléfono")]
        public string phone_pro { get; set; }

        [Display(Name = "Dirección")]
        public string address { get; set; }

        [Display(Name = "Nombre")]
        public string firstname { get; set; }

        [Display(Name = "Apellido")]
        public string lastname { get; set; }
    }
}
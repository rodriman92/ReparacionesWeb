using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReparacionesWeb.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        [Display(Name=("Cliente"))]
        [StringLength(40)]
        public string ApeNombre { get; set; }
        [Display(Name = ("Dirección"))]
        [StringLength(20)]
        
        public string Direccion { get; set; }
        [Display(Name = ("Tel"))]
        [StringLength(15)]
        public string Telefono { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        
        [StringLength(25)]
        public string Localidad { get; set; }

        public ICollection<Reparacion> Reparaciones { get; set; }
    }
}
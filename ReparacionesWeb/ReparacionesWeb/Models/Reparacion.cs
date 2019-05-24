using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReparacionesWeb.Models
{
    public class Reparacion
    {
        public int ReparacionID { get; set; }
        [Display(Name ="Equipo")]
        [StringLength(20)]
        public string DetalleEquipo { get; set; }
        [Display(Name = "Recepción")]
        [DataType(DataType.Date)]
        public DateTime FechaRecepcion { get; set; }
        [Display(Name = "Diagnóstico")]
        [StringLength(20)]
        public string Diagnostico { get; set; }
        [StringLength(40)]
        [Display(Name ="Obs")]
        public string Observaciones { get; set; }
       
        [Display(Name ="$")]
        public decimal CostoReparacion { get; set; }
        [Display(Name ="Estado")]
        public int EstadoReparacion { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Fecha de Pago")]
        public DateTime FechaPago { get; set; }

        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }
    }
}
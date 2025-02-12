using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WinetrackerGen.ApplicationCore.Enumerated.Winetracker;

namespace WebApplication.Models
{
    public class VentaViewModel
    {
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }
        public List<LineaPedidoViewModel> LineasPedido { get; set; }
        public float ImporteTotal { get; set; } // Total del importe
    }


}

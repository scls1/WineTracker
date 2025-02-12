using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WinetrackerGen.ApplicationCore.Enumerated.Winetracker;

namespace WebApplication.Models
{
    public class PedidoViewModel
    {
        public int PedidoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public List<LineaPedidoViewModel> LineasPedido { get; set; } // Lista de artículos en el pedido
        public float ImporteTotal { get; set; } // Total del importe
    }

}

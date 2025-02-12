using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WinetrackerGen.ApplicationCore.Enumerated.Winetracker;

namespace WebApplication.Models
{
    public class LineaPedidoViewModel
    {
        public int LineaPedidoId { get; set; }
        public string NombreArticulo { get; set; }
        public int Cantidad { get; set; }
        public float Importe { get; set; }
        public decimal ImporteTotal { get; set; }
        public string FotoArticulo { get; set; }
    }


}

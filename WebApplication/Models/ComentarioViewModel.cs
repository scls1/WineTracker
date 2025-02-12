using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WinetrackerGen.ApplicationCore.Enumerated.Winetracker;

namespace WebApplication.Models
{
    public class ComentarioViewModel
    {
        public string Usuario { get; set; }
        public string Texto { get; set; }
        public int NumLikes { get; set; }
        public string NombreUsuario { get; set; }
        public string Foto { get; set; }
        public float ValoracionMedia { get; set; }
    }


}

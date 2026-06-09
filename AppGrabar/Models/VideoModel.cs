using System;
using System.Collections.Generic;
using System.Text;

namespace AppGrabar.Models
{
    public class VideoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } 
        public string RutaArchivo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaGrabacion { get; set; }

    }
}

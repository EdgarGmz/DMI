using System;
using System.Collections.Generic;
using System.Text;

namespace AppCRUDFirebase.Models;

public  class Producto
{
    // Propiedades
    public string Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
}

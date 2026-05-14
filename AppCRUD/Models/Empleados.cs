using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCRUD.Models;

public class Empleados
{
    [PrimaryKey, AutoIncrement]
    public int IdEmp { get; set; }

    [MaxLength(50)]
    public string Nombre { get; set; }

    [MaxLength(50)]
    public string ApellidoPaterno { get; set; }

    [MaxLength(50)]
    public string ApellidoMaterno { get; set; }
 
    public int Edad { get; set; }
    public double Telefono { get; set; }
}

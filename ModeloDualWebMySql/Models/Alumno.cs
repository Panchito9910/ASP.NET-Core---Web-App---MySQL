using System;
using System.Collections.Generic;

namespace ModeloDualWebMySql.Models;

public partial class Alumno
{
    public int IdAlumno { get; set; }

    public string Matricula { get; set; } = null!;

    public string NombreAlumno { get; set; } = null!;

    public string ApellidoAlumno { get; set; } = null!;

    public int SemestreActual { get; set; }

    public string CorreoAlumno { get; set; } = null!;

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}

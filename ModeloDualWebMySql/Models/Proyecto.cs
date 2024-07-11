using System;
using System.Collections.Generic;

namespace ModeloDualWebMySql.Models;

public partial class Proyecto
{
    public int IdProyecto { get; set; }

    public string CodigoProyecto { get; set; } = null!;

    public string NombreProyecto { get; set; } = null!;

    public string CodigoEmpresa { get; set; } = null!;

    public string Matricula { get; set; } = null!;

    public virtual Empresa CodigoEmpresaNavigation { get; set; } = null!;

    public virtual Alumno MatriculaNavigation { get; set; } = null!;
}

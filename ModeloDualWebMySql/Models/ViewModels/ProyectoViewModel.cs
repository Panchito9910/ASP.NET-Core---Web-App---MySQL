using System.ComponentModel.DataAnnotations;

namespace ModeloDualWebMySql.Models.ViewModels
{
    public class ProyectoViewModel
    {
        public int IdProyecto { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name ="Código del proyecto")]
        public string CodigoProyecto { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Nombre del proyecto")]
        public string NombreProyecto { get; set; } = null!;

        [Required]
        [Display(Name = "Código de la empresa")]
        public string CodigoEmpresa { get; set; } = null!;

        [Required]
        [Display(Name = "Matrícula del alumno")]
        public string Matricula { get; set; } = null!;
    }
}

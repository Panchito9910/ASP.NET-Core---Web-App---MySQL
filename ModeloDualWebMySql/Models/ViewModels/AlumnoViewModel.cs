using System.ComponentModel.DataAnnotations;

namespace ModeloDualWebMySql.Models.ViewModels
{
    public class AlumnoViewModel
    {
        public int IdAlumno { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(9, MinimumLength = 5, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name ="Matrícula")]
        public string Matricula { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Nombre del alumno")]
        public string NombreAlumno { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Apellido del alumno")]
        public string ApellidoAlumno { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(5,9, ErrorMessage = "El campo {0} debe estar entre {1} y {2}")]
        [Display(Name = "Semestre actual")]
        public int SemestreActual { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(26, MinimumLength = 5, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Correo del alumno")]
        public string CorreoAlumno { get; set; } = null!;
    }
}

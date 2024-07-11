using System.ComponentModel.DataAnnotations;

namespace ModeloDualWebMySql.Models.ViewModels
{
    public class EmpresaViewModel
    {
        public int IdEmpresa { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name ="Código empresa")]
        public string CodigoEmpresa { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Nombre empresa")]
        public string NombreEmpresa { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Correo empresa")]
        public string CorreoEmpresa { get; set; } = null!;
    }
}

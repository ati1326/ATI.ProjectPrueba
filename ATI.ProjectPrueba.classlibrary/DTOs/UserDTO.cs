using ATI.ProjectPrueba.Classlibrary.Entities;
using System.ComponentModel.DataAnnotations;


namespace ATI.ProjectPrueba.Classlibrary.DTOs
{
    public class UserDTO : User
    {

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener al menos {2} y máximo {1} caracteres.")]
        public string Password { get; set; } = null!;

        [Compare("Password", ErrorMessage = "La contraseña y la confirmación de contraseña no coinciden.")]
        [Display(Name = "Confirmar contraseña")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener al menos {2} y máximo {1} caracteres.")]
        public string PasswordConfirm { get; set; } = null!;

    }

}


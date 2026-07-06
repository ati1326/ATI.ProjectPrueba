using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATI.ProjectPrueba.Classlibrary.Entities
{
    public class Category
    {
        //lo que  va a tener  el pais
        public int ID { get; set; }

        [Display(Name = "Categoria")]
        [MaxLength(100, ErrorMessage = "EL campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es Requerido ")]
        public String Name { get; set; } = null!;
    
    }
}

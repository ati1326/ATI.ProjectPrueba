using ATI.ProjectPrueba.Classlibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATI.ProjectPrueba.Classlibrary.Entities
{
    public class City : IEntityWithName
    {

        public int ID { get; set; }
        [Display(Name = "Ciudad")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public int StateID { get; set; }

        public State? State { get; set; }
    }

}

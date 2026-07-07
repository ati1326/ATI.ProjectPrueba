using ATI.ProjectPrueba.Classlibrary.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ATI.ProjectPrueba.Classlibrary.Entities
{
    public class Country : IEntityWithName

    {
        //lo que  va a tener  el pais
        public int ID { get; set; }

        [Display(Name = "Pais ")]
        [MaxLength(100, ErrorMessage = "EL campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es Requerido ")]
        public string Name { get; set; } = null!;

        public ICollection<State>? States { get; set; }

        [Display(Name = "Estados / Departamentos")]
        public int StatesNumber => States == null || States.Count == 0 ? 0 : States.Count;

    }
} 
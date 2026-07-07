using ATI.ProjectPrueba.Classlibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATI.ProjectPrueba.Classlibrary.Entities
{
    public class State : IEntityWithName
    {

        public int ID { get; set; }

        [Display(Name = "Estado / Departamento")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public int CountryID { get; set; }

        public Country? Country { get; set; }

        public ICollection<City>? Cities { get; set; }
        [Display(Name = "Ciudades")]
        public int CitiesNumber => Cities == null || Cities.Count == 0 ? 0 : Cities.Count;

    }

}


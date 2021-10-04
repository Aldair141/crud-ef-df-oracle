using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class PersonaDTO
    {
        public decimal id { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string nombres { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string apellidos { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime? fechaNacimiento { get; set; }
    }
}
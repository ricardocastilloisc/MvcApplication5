using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Dominio.Core.Entities
{
    class Curso
    {
        [DisplayName("Código del curso")]
        public int codigo_c { get; set; }

        [DisplayName("Nombre del Curso")]
        [Required(ErrorMessage = "Nombre del curso es reuerido")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "No más de 30 caracteres")]
        public string nombre_c { get; set; }

        [DisplayName("Email del Curso")]
        [Required(ErrorMessage = "Email del curso requerido")]
        [StringLength(50, ErrorMessage = "No más de 50 caracteres")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string correo_c { get; set; }

        [DisplayName("Crédito del curso")]
        [Required(ErrorMessage = "Número de crédito de curso es requrido")]
        [Range(1, 6)]
        public int credito_c { get; set; }
    }
}

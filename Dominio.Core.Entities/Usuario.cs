using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entities
{
    public class Usuario
    {
        [DisplayName("Usuario")]
        [Required(ErrorMessage = "Usuario Requerido")]
        public string usuario_u { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "Contraseña Requerida")]
        public string clave_u { get; set; }

        [DisplayName("Nombre")]
        public string nombreUsuario_u { get; set; }

    }
}

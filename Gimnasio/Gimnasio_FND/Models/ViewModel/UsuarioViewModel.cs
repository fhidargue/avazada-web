using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gimnasio_FND.Models.ViewModel
{
    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public int IdSucursal { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public string Contrasenia { get; set; }
    }
}

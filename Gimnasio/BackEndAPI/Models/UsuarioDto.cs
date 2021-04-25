using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Models
{
    public class UsuarioDto
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

        public int idEntrenador { get; set; }

        public virtual RolDto IdRolNavigation { get; set; }
        public virtual SucursalDto IdSucursalNavigation { get; set; }
    }
}

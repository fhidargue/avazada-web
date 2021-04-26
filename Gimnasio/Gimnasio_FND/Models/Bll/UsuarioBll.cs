using Gimnasio_FND.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gimnasio_FND.Models.Bll
{
    public class UsuarioBll
    {
        public static void CapitalizeName(UsuarioViewModel usuario)
        {
            usuario.Nombre = char.ToUpper(usuario.Nombre[0]) + usuario.Nombre.ToLower()[1..];
            usuario.Apellidos = char.ToUpper(usuario.Apellidos[0]) + usuario.Apellidos.ToLower()[1..];
        }
    }
}

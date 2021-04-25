using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gimnasio_FND.Models.ViewModel
{
    public class IdUsuarioClienteNavigation
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
        public object IdRolNavigation { get; set; }
        public object IdSucursalNavigation { get; set; }
    }

    public class IdUsuarioEntrenadorNavigation
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
        public object IdRolNavigation { get; set; }
        public object IdSucursalNavigation { get; set; }
    }

    public class IdEjercicioNavigation
    {
        public int IdEjercicio { get; set; }
        public string Descripcion { get; set; }
        public string Intensidad { get; set; }
        public string Equipo { get; set; }
    }

    public class RutinaXejercicio
    {
        public int IdRutinaEjercicio { get; set; }
        public int IdRutina { get; set; }
        public int IdEjercicio { get; set; }
        public int Repeticiones { get; set; }
        public int Series { get; set; }
        public IdEjercicioNavigation IdEjercicioNavigation { get; set; }

        public List<EjercicioViewModel> Ejercicios { get; set; }
    }

    public class RutinaViewModel
    {
        public int IdRutina { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuarioCliente { get; set; }
        public int IdUsuarioEntrenador { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public IdUsuarioClienteNavigation IdUsuarioClienteNavigation { get; set; }
        public IdUsuarioEntrenadorNavigation IdUsuarioEntrenadorNavigation { get; set; }
        public IList<RutinaXejercicio> RutinaXejercicios { get; set; }
        public List<EjercicioViewModel> Ejercicios { get; set; }
        public List<UsuarioViewModel> Usuarios { get; set; }
    }

}

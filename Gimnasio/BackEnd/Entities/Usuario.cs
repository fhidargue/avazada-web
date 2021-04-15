using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Bitacoras = new HashSet<Bitacora>();
            Medida = new HashSet<Medida>();
            RutinaIdUsuarioClienteNavigations = new HashSet<Rutina>();
            RutinaIdUsuarioEntrenadorNavigations = new HashSet<Rutina>();
            Subscripcions = new HashSet<Subscripcion>();
        }

        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public int IdSucursal { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public string Contrasenia { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual Sucursal IdSucursalNavigation { get; set; }
        public virtual ICollection<Bitacora> Bitacoras { get; set; }
        public virtual ICollection<Medida> Medida { get; set; }
        public virtual ICollection<Rutina> RutinaIdUsuarioClienteNavigations { get; set; }
        public virtual ICollection<Rutina> RutinaIdUsuarioEntrenadorNavigations { get; set; }
        public virtual ICollection<Subscripcion> Subscripcions { get; set; }
    }
}

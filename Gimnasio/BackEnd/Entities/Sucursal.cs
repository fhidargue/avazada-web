using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdSucursal { get; set; }
        public string Sede { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}

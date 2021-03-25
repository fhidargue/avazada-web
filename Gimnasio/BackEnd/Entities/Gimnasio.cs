using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Gimnasio
    {
        public Gimnasio()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdGimnasio { get; set; }
        public string Sede { get; set; }
        public string Contacto { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}

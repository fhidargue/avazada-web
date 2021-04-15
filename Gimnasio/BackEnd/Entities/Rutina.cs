using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Rutina
    {
        public Rutina()
        {
            RutinaXejercicios = new HashSet<RutinaXejercicio>();
        }

        public int IdRutina { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuarioCliente { get; set; }
        public int IdUsuarioEntrenador { get; set; }
        public DateTime FechaAsignacion { get; set; }

        public virtual Usuario IdUsuarioClienteNavigation { get; set; }
        public virtual Usuario IdUsuarioEntrenadorNavigation { get; set; }
        public virtual ICollection<RutinaXejercicio> RutinaXejercicios { get; set; }
    }
}

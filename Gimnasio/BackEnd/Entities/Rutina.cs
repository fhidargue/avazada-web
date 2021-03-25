using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Rutina
    {
        public Rutina()
        {
            RutinaEjercicios = new HashSet<RutinaEjercicio>();
        }

        public int IdRutina { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public int? IdUsuarioCliente { get; set; }
        public int? IdUsuarioEntrenador { get; set; }

        public virtual Usuario IdUsuarioClienteNavigation { get; set; }
        public virtual Usuario IdUsuarioEntrenadorNavigation { get; set; }
        public virtual ICollection<RutinaEjercicio> RutinaEjercicios { get; set; }
    }
}

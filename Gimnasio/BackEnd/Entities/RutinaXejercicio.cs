using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class RutinaXejercicio
    {
        public int IdRutinaEjercicio { get; set; }
        public int IdRutina { get; set; }
        public int IdEjercicio { get; set; }
        public int Repeticiones { get; set; }
        public int Series { get; set; }

        public virtual Ejercicio IdEjercicioNavigation { get; set; }
        public virtual Rutina IdRutinaNavigation { get; set; }
    }
}

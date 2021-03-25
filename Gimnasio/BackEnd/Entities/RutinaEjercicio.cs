using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class RutinaEjercicio
    {
        public int IdRutinasEjercicio { get; set; }
        public int? Repeticiones { get; set; }
        public int? Series { get; set; }
        public string Nivel { get; set; }
        public DateTime? Dia { get; set; }
        public int? IdRutina { get; set; }
        public int? IdEjercicio { get; set; }

        public virtual Ejercicio IdEjercicioNavigation { get; set; }
        public virtual Rutina IdRutinaNavigation { get; set; }
    }
}

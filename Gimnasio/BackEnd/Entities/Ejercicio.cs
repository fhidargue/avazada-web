using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Ejercicio
    {
        public Ejercicio()
        {
            RutinaEjercicios = new HashSet<RutinaEjercicio>();
        }

        public int IdEjercicio { get; set; }
        public string Descripcion { get; set; }
        public string Intensidad { get; set; }
        public string Equipo { get; set; }

        public virtual ICollection<RutinaEjercicio> RutinaEjercicios { get; set; }
    }
}

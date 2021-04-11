using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Ejercicio
    {
        public Ejercicio()
        {
            RutinaXejercicios = new HashSet<RutinaXejercicio>();
        }

        public int IdEjercicio { get; set; }
        public string Descripcion { get; set; }
        public string Intensidad { get; set; }
        public string Equipo { get; set; }

        public virtual ICollection<RutinaXejercicio> RutinaXejercicios { get; set; }
    }
}

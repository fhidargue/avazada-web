using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Models
{
    public class RutinaDto
    {
        public int IdRutina { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuarioCliente { get; set; }
        public int IdUsuarioEntrenador { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public virtual UsuarioDto IdUsuarioClienteNavigation { get; set; }
        public virtual UsuarioDto IdUsuarioEntrenadorNavigation { get; set; }

        public virtual ICollection<RutinaEjercicioDto> RutinaXejercicios { get; set; }
    }


    public class RutinaEjercicioDto
    {
        public int IdRutinaEjercicio { get; set; }
        public int IdRutina { get; set; }
        public int IdEjercicio { get; set; }
        public int Repeticiones { get; set; }
        public int Series { get; set; }
        public string Nivel { get; set; }
        public string Dia { get; set; }

        public virtual EjercicioDto IdEjercicioNavigation { get; set; }
        //public virtual RutinaDto IdRutinaNavigation { get; set; }
    }

    public class EjercicioDto
    {

        public int IdEjercicio { get; set; }
        public string Descripcion { get; set; }
        public string Intensidad { get; set; }
        public string Equipo { get; set; }
    }
}

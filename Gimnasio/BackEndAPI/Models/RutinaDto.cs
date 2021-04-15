using BackEnd.Entities;
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

        public virtual Usuario IdUsuarioClienteNavigation { get; set; }
        public virtual Usuario IdUsuarioEntrenadorNavigation { get; set; }
        public virtual ICollection<RutinaXejercicio> RutinaXejercicios { get; set; }
    }
}
